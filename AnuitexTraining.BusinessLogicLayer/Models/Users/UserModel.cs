using AnuitexTraining.BusinessLogicLayer.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AnuitexTraining.BusinessLogicLayer.Models.Users
{
    public class UserModel : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
