using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Entities
{
    public class ContactDbContext : DbContext
    {
        private string _connectionString =
            "Server=DESKTOP-N0OUUTB\\SQLEXPRESS;Database=ContactDb;Trusted_Connection=True;";
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Login)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(x => x.FirstName)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(x => x.LastName)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
