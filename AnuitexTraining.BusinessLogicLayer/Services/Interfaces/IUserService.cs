using AnuitexTraining.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public void Add(ApplicationUser user);
        public void Delete(int id);
        public ApplicationUser Get(int id);
        public IEnumerable<ApplicationUser> GetAll();
        public void Update(ApplicationUser user);
    }
}
