using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class ContactPL
    {
        public int ContactID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string EmailType { get; set; }
        public string EmailAddresses { get; set; }
    }
}
