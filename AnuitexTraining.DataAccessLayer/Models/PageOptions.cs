using Microsoft.Data.SqlClient;

namespace AnuitexTraining.DataAccessLayer.Models
{
    public class PageOptions<T>
    {
        public T Filter;
        public int Page;
        public int PageSize;
        public string SortField;
        public SortOrder SortOrder;
    }
}