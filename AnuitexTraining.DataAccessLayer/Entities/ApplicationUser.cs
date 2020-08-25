using Microsoft.AspNetCore.Identity;
using System;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }

        public ApplicationUser() : base()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
