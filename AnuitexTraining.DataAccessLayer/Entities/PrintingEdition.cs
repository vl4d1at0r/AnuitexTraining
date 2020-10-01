using System.Collections.Generic;
using AnuitexTraining.DataAccessLayer.Entities.Base;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CurrencyType Currency { get; set; }
        public PrintingEditionType Type { get; set; }
        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}