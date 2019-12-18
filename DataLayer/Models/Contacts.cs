using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
    }
}