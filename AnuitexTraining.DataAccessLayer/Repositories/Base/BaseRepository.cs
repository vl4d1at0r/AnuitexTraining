using AnuitexTraining.DataAccessLayer.AppContext;

namespace AnuitexTraining.DataAccessLayer.Repositories.Base
{
    public class BaseRepository
    {
        protected ApplicationContext db;

        public BaseRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
