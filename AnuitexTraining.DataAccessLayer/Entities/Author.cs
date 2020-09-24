using AnuitexTraining.DataAccessLayer.Entities.Base;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public AuthorInPrintingEdition AuthorInPrintingEdition { get; set; }
    }
}