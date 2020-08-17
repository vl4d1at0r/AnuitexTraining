using AnuitexTraining.DataAccessLayer.AppContext;
using System;

namespace AnuitexTraining.DataAccessLayer.Repositories.Base
{
    public class BaseRepository : IDisposable
    {
        protected ApplicationContext db;
        private bool disposed;

        public BaseRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
