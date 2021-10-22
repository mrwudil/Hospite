using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data
{
    public class AppUser : IdentityUser
    {


        public string Name { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }

        public bool IsAvailble { get; set; } = false;

        // One AppUser to Many Relationship
        public virtual ICollection<Schedule> Schedules { get; set; }
        public AppUser()
        {
            Schedules = new HashSet<Schedule>();
        }
    }
}
