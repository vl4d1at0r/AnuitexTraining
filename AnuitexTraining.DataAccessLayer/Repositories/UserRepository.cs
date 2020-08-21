using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository<ApplicationUser>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
