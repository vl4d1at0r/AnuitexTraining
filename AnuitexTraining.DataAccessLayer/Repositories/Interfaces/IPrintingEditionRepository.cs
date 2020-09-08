using System.Collections.Generic;
using System.Threading.Tasks;
using AnuitexTraining.DataAccessLayer.Entities;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        public Task<IEnumerable<PrintingEdition>> GetPageAsync(int page, int pageSize, PrintingEdition filter = null,
            string author = null, string orderField = null, bool descending = false);
    }
}