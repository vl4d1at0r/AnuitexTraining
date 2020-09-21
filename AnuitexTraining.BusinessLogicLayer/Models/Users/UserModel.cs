using AnuitexTraining.BusinessLogicLayer.Models.Base;

namespace AnuitexTraining.BusinessLogicLayer.Models.Users
{
    public class UserModel : BaseModel
    {
        public bool IsBlocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}