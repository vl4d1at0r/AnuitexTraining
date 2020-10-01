using System.Collections.Generic;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public PrintingEditionType Type { get; set; }
        public CurrencyType Currency { get; set; }
        public List<string> Authors { get; set; }
    }
}