using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLayer.Services;
using ContactManager.Models;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAndEmailController : ControllerBase
    {
        // GET: api/ContactAndEmail
        [HttpGet("GetAllRecords")]
        public IQueryable GetAllRecords()
        {
            var result = BusLayer.GetAllRecords();
            return (result.AsQueryable());
        }
        //// GET: api/ContactAndEmail/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        // POST: api/ContactAndEmail
        [HttpPost("Post")]
        public object Post(object contact)
        {
            EmailAddress e = JsonConvert.DeserializeObject<EmailAddress>(contact.ToString());
            Contact c = JsonConvert.DeserializeObject<Contact>(contact.ToString());
            //Mapper.MapToDB(e);
            contact = BusLayer.Create(c, e);
            return contact;
        }
        // PUT: api/ContactAndEmail/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
