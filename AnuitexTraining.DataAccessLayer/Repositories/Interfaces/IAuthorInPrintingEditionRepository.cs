using AnuitexTraining.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnuitexTraining.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseRepository<AuthorInPrintingEdition>
    {
        public Task<AuthorInPrintingEdition> GetByPrintingEditionIdAsync(long id);
        public Task DeleteAllForPrintingEditionId(long id);
    }
}
