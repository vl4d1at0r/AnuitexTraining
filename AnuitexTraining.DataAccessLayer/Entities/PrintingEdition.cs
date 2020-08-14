using AnuitexTraining.DataAccessLayer.Entities.Base;
using AnuitexTraining.DataAccessLayer.Entities.Enums;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}
