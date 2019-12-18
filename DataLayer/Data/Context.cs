using DataLayer.Models;
using DataLayer.Services;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {

        }
        public ContextDB(DbContextOptions<ContextDB> options)
           : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EmailAddress> Emails { get; set; }
        //public DbSet<ContactDB> contactsDB { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            AppSettigns appSettigns = new AppSettigns();


            Settings.settings(appSettigns);
            options.UseSqlServer(appSettigns.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().ToTable("Contacts");
            builder.Entity<EmailAddress>().ToTable("Emails");
        }
    }
}