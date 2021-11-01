using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data
{
    public class Schedule
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccessCode { get; set; }
        public bool IsGranted { get; set; } = false;
        public string Tag { get; set; }
        public string Purpose { get; set; }
        public string FromWhere { get; set; }
        public string ToWhom { get; set; }

        public bool Cancelled { get; set; } = false;
        public DateTime TimeIn { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;
        public DateTime TimeOut { get; set; }


        // One to Many Schedule Relationship
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
