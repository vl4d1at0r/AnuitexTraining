using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseRepository<AuthorInPrintingEdition>
    {
        public Task<AuthorInPrintingEdition> GetByPrintingEditionIdAsync(long id);
        public Task DeleteAllForPrintingEditionIdAsync(long id);
    }
}