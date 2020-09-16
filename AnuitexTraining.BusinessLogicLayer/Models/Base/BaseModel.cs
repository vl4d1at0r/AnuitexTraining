using System;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Models.Base
{
    public class BaseModel
    {
        public BaseModel()
        {
            Errors = new List<string>();
        }

        public long Id { get; set; }
        public List<string> Errors { get; set; }
        public DateTime CreationDate { get; set; }
    }
}