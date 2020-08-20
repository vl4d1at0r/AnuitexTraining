using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.DataAccessLayer.Entities;
using System;

namespace AnuitexTraining.BusinessLogicLayer.Models.Users
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public ApplicationUser ToDataAccessLayerEntity()
        {
            return new ApplicationUser()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                PasswordHash = PasswordHash,
                PhoneNumber = PhoneNumber
            };
        }

        public static UserModel ToBusinessLogicLayerModel(ApplicationUser user)
        {
            return new UserModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
