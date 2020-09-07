using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class PrintingEditionMapper : BaseMapper<PrintingEdition, PrintingEditionModel>
    {
        public override PrintingEdition Map(PrintingEditionModel item)
        {
            return new PrintingEdition
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
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
                Currency = item.Currency,
                Description = item.Description,
                Price = item.Price,
                Title = item.Title,
                Type = item.Type
            };
        }
    }
}