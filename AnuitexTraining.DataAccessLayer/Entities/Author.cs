using System.Collections.Generic;
using AnuitexTraining.DataAccessLayer.Entities.Base;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}