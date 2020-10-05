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

        public async Task<PageDataModel<PrintingEditionModel>> GetPageAsync(
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
                        Price = pageModel.Filter.Price,
                        Types = pageModel.Filter.Types,
                        CreationDate = pageModel.Filter.CreationDate
                    },
                Page = pageModel.Page,
                PageSize = pageModel.PageSize,
                SortField = pageModel.SortField,
                SortOrder = pageModel.SortOrder
            });

            List<PrintingEditionModel> printingEditionModels = _printingEditionMapper.Map(printingEditions);
            printingEditionModels.ForEach(item =>
                item.Price = _exchangeRateProvider.Exchange(item.Currency, pageModel.Filter.Currency, item.Price));
            
            if (pageModel.SortOrder != SortOrder.Unspecified)
            {
                printingEditionModels = await printingEditionModels.AsQueryable().OrderBy($"{pageModel.SortField} {pageModel.SortOrder.ToString()}").ToListAsync();
            }

            return new PageDataModel<PrintingEditionModel>
            {
                Data = printingEditionModels,
                Length = printingEditions.TotalItemCount
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
                });
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

            printingEdition.Price = model.Price;
            printingEdition.Title = model.Title;
            printingEdition.Type = model.Type;
            printingEdition.Description = model.Description;
            printingEdition.Currency = model.Currency;

            List<Author> authors = new List<Author>();
            model.Authors.ForEach(async item =>
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Author author = await _authorRepository.GetByNameAsync(item);
                    if (author is null)
                    {
                        author = new Author
                        {
                            Name = item
                        };
                        await _authorRepository.AddAsync(author);
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
                });
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