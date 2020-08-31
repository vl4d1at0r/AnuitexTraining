using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories
{
    public class AuthorInPrintingEditionRepository : BaseRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(ApplicationContext context) : base(context) { }

        public async Task DeleteAllForPrintingEditionId(long id)
        {
            _dbSet.RemoveRange(_dbSet.Where(item => item.PrintingEditionId == id));
            await SaveAsync();
        }

        public async Task<AuthorInPrintingEdition> GetByPrintingEditionIdAsync(long id)
        {
            return await _dbSet.Include(item => item.Author).Include(item => item.PrintingEdition).FirstOrDefaultAsync(item => item.PrintingEditionId == id);
        }
    }
}
