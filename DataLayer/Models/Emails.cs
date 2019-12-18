using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class EmailAddress
    {
        [Key]
        public int EmailID { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EmailType EmailType { get; set; }
        [ForeignKey("Contact")]
        public int ContactID { get; set; }
        public virtual Contact Contact { get; set; }

    }
    public enum EmailType
    {
        Personal, Business
    }
}
