using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Enums.Enums;
using Microsoft.Data.SqlClient;
using System.Linq;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private IPrintingEditionRepository _printingEditionRepository;
        private PrintingEditionMapper _printingEditionMapper;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, PrintingEditionMapper printingEditionMapper)
        {
            _printingEditionMapper = printingEditionMapper;
            _printingEditionRepository = printingEditionRepository;
        }

        public async Task<IPagedList<PrintingEditionModel>> GetPageAsync(PrintingEditionModel filter, string orderField, bool descending, int page, int pageSize)
        {
            List<PrintingEdition> printingEditions = await _printingEditionRepository.GetAllAsync();
            printingEditions = printingEditions.Where(item =>
            {
                if (item.Title.ToLower().Contains(filter.Title.ToLower()) &&
                    item.Description.ToLower().Contains(filter.Description.ToLower()) &&
                    (item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default ) &&
                    (item.Currency == filter.Currency || filter.Currency == CurrencyType.None) &&
                    (item.Price.ToString().Contains(filter.Price.ToString()) || filter.Price == default) &&
                    (item.Type == filter.Type || filter.Type == PrintingEditionType.None))
                {
                    return true;
                }
                return false;
            }).ToList();
            if (descending)
            {
                printingEditions = printingEditions.AsQueryable().OrderBy(orderField, SortOrder.Descending.ToString()).ToList();
            }
            else
            {
                printingEditions = printingEditions.AsQueryable().OrderBy(orderField, SortOrder.Ascending.ToString()).ToList();
            }
            return _printingEditionMapper.Map(printingEditions).ToPagedList(page, pageSize);
        }

        public async Task AddAsync(PrintingEditionModel item)
        {
            if(string.IsNullOrEmpty(item.Title))
            {
                item.Errors.Add(ExceptionsInfo.InvalidTitle);
            }
            if(string.IsNullOrEmpty(item.Description))
            {
                item.Errors.Add(ExceptionsInfo.InvalidDescription);
            }
            if(item.Type == PrintingEditionType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrintingEditionType);
            }
            if(item.Currency == CurrencyType.None)
            {
                item.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
            }
            if(item.Price == default)
            {
                item.Errors.Add(ExceptionsInfo.InvalidPrice);
            }
            await _printingEditionRepository.AddAsync(_printingEditionMapper.Map(item));
        }

        public async Task DeleteAsync(long id)
        {
            await _printingEditionRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(PrintingEditionModel item)
        {
            await _printingEditionRepository.UpdateAsync(_printingEditionMapper.Map(item));
        }
    }
}
