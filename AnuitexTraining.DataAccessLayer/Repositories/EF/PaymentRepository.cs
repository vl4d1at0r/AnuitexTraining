using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.EF.Base;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;

namespace AnuitexTraining.DataAccessLayer.Repositories.EF
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}