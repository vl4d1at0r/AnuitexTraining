using AnuitexTraining.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        
    }
}
