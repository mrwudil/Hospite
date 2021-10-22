using Hospite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public bool IsAvailable { get; set; }
        public IEnumerable<Schedule> GetSchedules { get; set; }

        public Address Address { get; set; }
    }
}
