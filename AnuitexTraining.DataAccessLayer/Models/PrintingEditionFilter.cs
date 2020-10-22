using System;
using System.Collections.Generic;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Models
{
    public class PrintingEditionFilter
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public CurrencyType Currency { get; set; }
        public List<PrintingEditionType> Types { get; set; }
        public DateTime CreationDate { get; set; }
        public string SearchString { get; set; }
    }
}