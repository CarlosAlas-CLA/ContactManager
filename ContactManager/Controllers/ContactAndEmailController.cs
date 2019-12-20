using System.Linq;
using BusinessLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAndEmailController : ControllerBase
    {
        //GetAllRecords
        [HttpGet("GetAllRecords")]
        public IQueryable GetAllRecords()
        {
            var result = DelUpdAdd.GetAllRecords();
            return (result.AsQueryable());
        }
        //Add
        [HttpPost("Post")]
        public object Post(object contact)
        {
            EmailAddress e = JsonConvert.DeserializeObject<EmailAddress>(contact.ToString());
            Contact c = JsonConvert.DeserializeObject<Contact>(contact.ToString());
            contact = DelUpdAdd.Create(c, e);
            return contact;
        }
        //Update
        [HttpPost("Update")]
        public void Update(object contact)
        {
            EmailAddress e = JsonConvert.DeserializeObject<EmailAddress>(contact.ToString());
            Contact c = JsonConvert.DeserializeObject<Contact>(contact.ToString());
            DelUpdAdd.Update(c, e);
        }
        // Delete
        [HttpPost("Delete")]
        public void Delete(object id)
        {
            Contact contact = JsonConvert.DeserializeObject<Contact>(id.ToString());
            DelUpdAdd.Delete(contact.ContactID);
        }
    }
}
