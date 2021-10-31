using Hospite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Models
{
    public class RegisterVisitorViewModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
   
        public string Purpose { get; set; }

        public string FromWhere { get; set; }
        public string ToWhom { get; set; }
        public string TagNo { get; set; }
    }
}
