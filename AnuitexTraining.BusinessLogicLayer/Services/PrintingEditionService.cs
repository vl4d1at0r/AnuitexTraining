using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Enums.Enums;
using System.Linq;
using static AnuitexTraining.Shared.Constants.Constants;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using System.Net;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private IPrintingEditionRepository _printingEditionRepository;
        private PrintingEditionMapper _printingEditionMapper;
        private IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private IAuthorRepository _authorRepository;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            PrintingEditionMapper printingEditionMapper, IAuthorRepository authorRepository)
        {
            _printingEditionMapper = printingEditionMapper;
            _printingEditionRepository = printingEditionRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter,
            string orderField, bool descending, int page, int pageSize)
        {
            IEnumerable<PrintingEdition> printingEditions = await _printingEditionRepository.GetPageAsync(page,
                pageSize, _printingEditionMapper.Map(filter), filter.AuthorName, orderField, descending);
            List<PrintingEditionModel> models = _printingEditionMapper.Map(printingEditions);
            models.ForEach(item =>
                item.AuthorName = _authorInPrintingEditionRepository.GetByPrintingEditionIdAsync(item.Id).Result.Author
                    .Name);
            return models;
        }

        public async Task AddAsync(PrintingEditionModel item)
        {
            if (string.IsNullOrEmpty(item.Title))
            {
                item.Errors.Add(ExceptionsInfo.InvalidTitle);
            }

            if (string.IsNullOrEmpty(item.Description))
            {
                item.Errors.Add(ExceptionsInfo.InvalidDescription);
            }

            if (string.IsNullOrEmpty(item.AuthorName))
            {
                item.Errors.Add(ExceptionsInfo.InvalidAuthor);
            }

            if (item.Type == PrintingEditionType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrintingEditionType);
            }

            if (item.Currency == CurrencyType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
            }

            if (item.Price == default)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrice);
            }

            if (item.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, item.Errors);
            }

            Author author = await _authorRepository.GetByNameAsync(item.AuthorName);
            if (author is null)
            {
                author = new Author {Name = item.AuthorName};
                await _authorRepository.AddAsync(author);
            }

            PrintingEdition printingEdition = _printingEditionMapper.Map(item);
            await _printingEditionRepository.AddAsync(printingEdition);
            await _authorInPrintingEditionRepository.AddAsync(new AuthorInPrintingEdition
                {PrintingEditionId = printingEdition.Id, AuthorId = author.Id});
        }

        public async Task DeleteAsync(long id)
        {
            if ((await _printingEditionRepository.GetAsync(id)) is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            await _printingEditionRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(PrintingEditionModel item)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetAsync(item.Id);
            if (printingEdition is null)
            {
                item.Errors.Add(ExceptionsInfo.InvalidId);
            }

            if (string.IsNullOrEmpty(item.Title))
            {
                item.Errors.Add(ExceptionsInfo.InvalidTitle);
            }

            if (string.IsNullOrEmpty(item.Description))
            {
                item.Errors.Add(ExceptionsInfo.InvalidDescription);
            }

            if (string.IsNullOrEmpty(item.AuthorName))
            {
                item.Errors.Add(ExceptionsInfo.InvalidAuthor);
            }

            if (item.Type == PrintingEditionType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrintingEditionType);
            }

            if (item.Currency == CurrencyType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
            }

            if (item.Price == default)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrice);
            }

            if (item.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, item.Errors);
            }

            printingEdition.Price = item.Price;
            printingEdition.Title = item.Title;
            printingEdition.Type = item.Type;
            printingEdition.Description = item.Description;
            printingEdition.Currency = item.Currency;
            Author author = await _authorRepository.GetByNameAsync(item.AuthorName);
            if (author is null)
            {
                author = new Author {Name = item.AuthorName};
                await _authorRepository.AddAsync(author);
            }

            await _printingEditionRepository.UpdateAsync(printingEdition);
            await _authorInPrintingEditionRepository.DeleteAllForPrintingEditionIdAsync(item.Id);
            await _authorInPrintingEditionRepository.AddAsync(new AuthorInPrintingEdition
                {PrintingEditionId = item.Id, AuthorId = author.Id});
        }

        public async Task<PrintingEditionModel> GetAsync(long id)
        {
            PrintingEdition printingEdition = await _printingEditionRepository.GetAsync(id);
            if (printingEdition is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            AuthorInPrintingEdition authorInPrintingEdition =
                await _authorInPrintingEditionRepository.GetByPrintingEditionIdAsync(id);
            PrintingEditionModel model = _printingEditionMapper.Map(printingEdition);
            model.AuthorName = authorInPrintingEdition.Author.Name;
            return model;
        }
    }
}