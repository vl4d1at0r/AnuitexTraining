using System;
using Microsoft.AspNetCore.Identity;

namespace AnuitexTraining.DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser()
        {
            CreationDate = DateTime.UtcNow;
            IsBlocked = false;
        }

        public bool IsBlocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}