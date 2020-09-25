using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;

namespace AnuitexTraining.DataAccessLayer.Models
{
    public class AuthorPage
    {
        public Author Filter;
        public int Page;
        public int PageSize;
        public string SortField;
        public SortOrder SortOrder;
    }
}