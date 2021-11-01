using Hospite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospite.Models
{
    public class SignOutViewModel
    {
        public string VisitorName { get; set; }
        public string UserId { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string TagNo { get; set; }
        public string PhoneNumber { get; set; }
        public bool Cancelled { get; set; }
        public DateTime BookingTime { get; set; }
        public string FromWhere { get; set; }
        public string Purpose { get; set; }
        public string ToWhom { get; set; }
        public DateTime TimeIn { get; set; }
        public bool GrantedAccess { get; set; }
        public DateTime TimeOut { get; set; }
        public Address Address { get; set; }

    }
}
