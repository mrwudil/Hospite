using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Models
{
    public class ScheduledUserViewModel
    {
     
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Contact { get; set; }
        public string TagNo { get; set; }
        public bool Cancelled { get; set; }
        public DateTime BookingTime { get; set; }

        public bool IsGranted { get; set; }
    }
}
