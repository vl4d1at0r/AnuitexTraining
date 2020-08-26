﻿using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Models.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public List<string> Errors { get; set; }

        public BaseModel()
        {
            Errors = new List<string>();
        }
    }
}
