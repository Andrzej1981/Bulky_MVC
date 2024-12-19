using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bulky.Utility
{
    public class SecretArea
    {
        public string KeyForAdm { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; }
        public string HostSmtp { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
