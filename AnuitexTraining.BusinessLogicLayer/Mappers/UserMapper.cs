using AnuitexTraining.BusinessLogicLayer.Mappers.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Users;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.BusinessLogicLayer.Mappers
{
    public class UserMapper : BaseMapper<ApplicationUser, UserModel>
    {
        public override UserModel Map(ApplicationUser item)
        {
            return new UserModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                NickName = item.UserName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                CreationDate = item.CreationDate,
                IsBlocked = item.IsBlocked
            };
        }

        public override ApplicationUser Map(UserModel item)
        {
            return new ApplicationUser
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.NickName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                CreationDate = item.CreationDate ?? default,
                IsBlocked = item.IsBlocked ?? default
            };
        }
    }
}