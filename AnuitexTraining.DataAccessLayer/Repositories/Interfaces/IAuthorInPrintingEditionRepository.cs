using AnuitexTraining.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseRepository<AuthorInPrintingEdition>
    {
        public Task<AuthorInPrintingEdition> GetByPrintingEditionIdAsync(long id);
        public Task DeleteAllForPrintingEditionIdAsync(long id);
    }
}