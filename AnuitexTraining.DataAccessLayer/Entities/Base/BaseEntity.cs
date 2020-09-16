using System;

namespace AnuitexTraining.DataAccessLayer.Entities.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}