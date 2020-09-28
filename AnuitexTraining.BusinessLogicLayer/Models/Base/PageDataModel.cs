using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Models.Base
{
    public class PageDataModel<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Length { get; set; }
    }
}