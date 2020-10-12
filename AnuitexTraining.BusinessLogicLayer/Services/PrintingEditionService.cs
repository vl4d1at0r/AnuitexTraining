using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Authors;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Providers;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using X.PagedList;
using static AnuitexTraining.Shared.Enums.Enums;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly PrintingEditionMapper _printingEditionMapper;
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly ExchangeRateProvider _exchangeRateProvider;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            PrintingEditionMapper printingEditionMapper, IAuthorRepository authorRepository,
            ExchangeRateProvider exchangeRateProvider)
        {
            _printingEditionMapper = printingEditionMapper;
            _printingEditionRepository = printingEditionRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _authorRepository = authorRepository;
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<PrintingEditionPageDataModel> GetPageAsync(
            PageModel<PrintingEditionFilterModel> pageModel)
        {
            var printingEditions = await _printingEditionRepository.GetPageAsync(new PageOptions<PrintingEditionFilter>
            {
                Filter = pageModel.Filter == null
                    ? null
                    : new PrintingEditionFilter
                    {
                        Title = pageModel.Filter.Title,
                        Description = pageModel.Filter.Description,
                        Currency = pageModel.Filter.Currency,
                        MinPrice = pageModel.Filter.MinPrice,
                        MaxPrice = pageModel.Filter.MaxPrice,
                        Types = pageModel.Filter.Types,
                        CreationDate = pageModel.Filter.CreationDate,
                        SearchString = pageModel.Filter.SearchString
                    },
                Page = pageModel.Page,
                PageSize = pageModel.PageSize,
                SortField = pageModel.SortField,
                SortOrder = pageModel.SortOrder
            });

            List<PrintingEditionModel> printingEditionModels = _printingEditionMapper.Map(printingEditions);
            PriceRange priceRange = await _printingEditionRepository.GetPriceRangeAsync(pageModel.Filter.Currency);

            return new PrintingEditionPageDataModel
            {
                Data = printingEditionModels,
                Length = printingEditions.TotalItemCount,
                MinPrice = priceRange.MinPrice,
                MaxPrice = priceRange.MaxPrice
            };
        }

        public async Task AddAsync(PrintingEditionModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                model.Errors.Add(ExceptionsInfo.InvalidTitle);
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Errors.Add(ExceptionsInfo.InvalidDescription);
            }

            if (model.Type == PrintingEditionType.None)
            {
                model.Errors.Add(ExceptionsInfo.InvalidPrintingEditionType);
            }

            if (model.Currency == CurrencyType.None)
            {
                model.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
            }

            if (model.Price == default)
            {
                model.Errors.Add(ExceptionsInfo.InvalidPrice);
            }

            if (model.Authors is null)
            {
                model.Errors.Add(ExceptionsInfo.InvalidAuthor);
            }

            if (model.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, model.Errors);
            }

            model.Price = _exchangeRateProvider.ExchangeToUSD(model.Price, model.Currency);
            model.Currency = CurrencyType.USD;

            List<Author> authors = new List<Author>();
            model.Authors.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Author author = _authorRepository.GetByNameAsync(item).Result;
                    if (author is null)
                    {
                        author = new Author
                        {
                            Name = item
                        };
                        _authorRepository.AddAsync(author);
                    }

                    authors.Add(author);
                }
            });

            var printingEdition = _printingEditionMapper.Map(model);
            await _printingEditionRepository.AddAsync(printingEdition);
            authors.ForEach(item =>
            {
                _authorInPrintingEditionRepository.AddAsync(new AuthorInPrintingEdition
                {
                    AuthorId = item.Id,
                    PrintingEditionId = printingEdition.Id
                }).Wait();
            });
        }

        public async Task DeleteAsync(long id)
        {
            if (await _printingEditionRepository.GetAsync(id) is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            await _printingEditionRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(PrintingEditionModel model)
        {
            var printingEdition = await _printingEditionRepository.GetAsync(model.Id);
            if (printingEdition is null)
            {
                model.Errors.Add(ExceptionsInfo.InvalidId);
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                model.Errors.Add(ExceptionsInfo.InvalidTitle);
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Errors.Add(ExceptionsInfo.InvalidDescription);
            }

            if (model.Type == PrintingEditionType.None)
            {
                model.Errors.Add(ExceptionsInfo.InvalidPrintingEditionType);
            }

            if (model.Currency == CurrencyType.None)
            {
                model.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
            }

            if (model.Price == default)
            {
                model.Errors.Add(ExceptionsInfo.InvalidPrice);
            }

            if (model.Authors is null)
            {
                model.Errors.Add(ExceptionsInfo.InvalidAuthor);
            }

            if (model.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, model.Errors);
            }

            printingEdition.Price = _exchangeRateProvider.ExchangeToUSD(model.Price, model.Currency);
            printingEdition.Title = model.Title;
            printingEdition.Type = model.Type;
            printingEdition.Description = model.Description;

            List<Author> authors = new List<Author>();
            model.Authors.ForEach(item =>
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Author author = _authorRepository.GetByNameAsync(item).Result;
                    if (author is null)
                    {
                        author = new Author
                        {
                            Name = item
                        };
                        _authorRepository.AddAsync(author).Wait();
                    }

                    authors.Add(author);
                }
            });

            await _printingEditionRepository.UpdateAsync(printingEdition);
            await _authorInPrintingEditionRepository.DeleteAllForPrintingEditionIdAsync(model.Id);
            authors.ForEach(item =>
            {
                _authorInPrintingEditionRepository.AddAsync(new AuthorInPrintingEdition
                {
                    AuthorId = item.Id,
                    PrintingEditionId = printingEdition.Id
                }).Wait();
            });
        }

        public async Task<PrintingEditionModel> GetAsync(long id)
        {
            var printingEdition = await _printingEditionRepository.GetAsync(id);
            if (printingEdition is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            var model = _printingEditionMapper.Map(printingEdition);
            model.Authors = await printingEdition.AuthorInPrintingEditions.Select(item => item.Author.Name)
                .ToListAsync();
            return model;
        }
    }
}