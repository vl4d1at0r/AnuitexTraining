using System.Linq;
using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Providers;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class PrintingEditionMapper : BaseMapper<PrintingEdition, PrintingEditionModel>
    {
        private ExchangeRateProvider _exchangeRateProvider;
        
        public PrintingEditionMapper(ExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }
        
        public override PrintingEdition Map(PrintingEditionModel item)
        {
            return new PrintingEdition
            {
                Id = item.Id,
                CreationDate = item.CreationDate ?? default,
                Currency = item.Currency,
                Description = item.Description,
                Price = item.Price,
                Title = item.Title,
                Type = item.Type
            };
        }

        public override PrintingEditionModel Map(PrintingEdition item)
        {
            return new PrintingEditionModel
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
                Description = item.Description,
                Currency = item.Currency,
                Price = item.Price,
                Title = item.Title,
                Type = item.Type,
                Authors = item.AuthorInPrintingEditions.Select(navigation => navigation.Author.Name).ToList()
            };
        }
    }
}