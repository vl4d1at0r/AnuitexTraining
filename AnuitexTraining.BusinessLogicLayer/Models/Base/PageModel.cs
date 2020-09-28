using Microsoft.Data.SqlClient;

namespace AnuitexTraining.BusinessLogicLayer.Models.Base
{
    public class PageModel<T>
    {
        public T Filter { get; set; }
        public int Page{ get; set; }
        public int PageSize{ get; set; }
        public string SortField{ get; set; }
        public SortOrder SortOrder{ get; set; }
    }
}