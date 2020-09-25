using Microsoft.Data.SqlClient;

namespace AnuitexTraining.BusinessLogicLayer.Models.Authors
{
    public class AuthorPageModel
    {
        public AuthorModel Filter;
        public int Page;
        public int PageSize;
        public string SortField;
        public SortOrder SortOrder;
    }
}