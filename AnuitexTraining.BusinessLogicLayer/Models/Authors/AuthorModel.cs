using System.Collections.Generic;
using AnuitexTraining.BusinessLogicLayer.Models.Base;

namespace AnuitexTraining.BusinessLogicLayer.Models.Authors
{
    public class AuthorModel : BaseModel
    {
        public string Name { get; set; }
        public List<string> Products { get; set; }
    }
}