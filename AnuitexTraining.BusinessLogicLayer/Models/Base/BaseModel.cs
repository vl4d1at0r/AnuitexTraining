using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Models.Base
{
    public class BaseModel
    {
        public ICollection<string> Errors = new List<string>();
    }
}
