using AnuitexTraining.BusinessLogicLayer.Models.Base;

namespace AnuitexTraining.BusinessLogicLayer.Models.PrintingEditions
{
    public class PrintingEditionPageDataModel : PageDataModel<PrintingEditionModel>
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}