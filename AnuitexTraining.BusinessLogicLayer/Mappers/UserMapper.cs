using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class UserMapper : BaseMapper<ApplicationUser, UserModel>
    {
        public override UserModel Map(ApplicationUser item)
        {
            return new UserModel()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            };
        }

        public override ApplicationUser Map(UserModel item)
        {
            return new ApplicationUser()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            };
        }
    }
}
