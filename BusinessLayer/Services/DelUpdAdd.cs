﻿using DataLayer.Data;
using DataLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer.Services
{
    public class DelUpdAdd
    {
        private static ContextDB dataBase = new ContextDB();
        public static IEnumerable GetAllRecords()
        {
            var result1 = dataBase.Emails.ToList();
            var result2 = dataBase.Contacts.ToList();
            var query = from p in result1
                        where p.ContactID != 0
                        from r in result2
                        where r.ContactID == p.ContactID
                        select new { p.ContactID, emailT = p.EmailType.ToString(), p.Email, r.FirstName, r.LastName };
            return (query.ToList());
        }
        public static void Delete(int id)
        {
            EmailAddress email = new EmailAddress();
            Contact contact = dataBase.Contacts.Find(id);
            dataBase.Contacts.Remove(contact);
            dataBase.SaveChanges();
        }
        public static void Update(Contact contact, int id)
        {
            Contact c = dataBase.Contacts.Find(id);
            Mapper.MapFromObjectToObject(contact, c);
            dataBase.Contacts.Update(c);
            dataBase.SaveChanges();
        }
        public static object Create(Contact contact, EmailAddress email)
        {
            dataBase.Contacts.Add(contact);
            dataBase.SaveChanges();
            email.ContactID = contact.ContactID;
            dataBase.Emails.Add(email);
            dataBase.SaveChanges();
            var result1 = dataBase.Emails.ToList();
            var result2 = dataBase.Contacts.ToList();
            var query = from p in result1
                        where p.ContactID == contact.ContactID
                        from r in result2
                        where r.ContactID == p.ContactID
                        select new { p.ContactID, emailT = p.EmailType.ToString(), p.Email, r.FirstName, r.LastName };
            return query;
        }
    }
}