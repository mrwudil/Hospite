using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data
{
    public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StreetNo { get; set; }
        public string City { get; set; }
        public string AddressTitle { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }

        
    }
}
