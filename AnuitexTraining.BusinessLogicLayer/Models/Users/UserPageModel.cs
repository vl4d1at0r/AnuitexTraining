using System;
using Microsoft.Data.SqlClient;

namespace AnuitexTraining.BusinessLogicLayer.Models.Users
{
    [Serializable]
    public class UserPageModel
    {
        public UserModel Filter { get; set; }
        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}