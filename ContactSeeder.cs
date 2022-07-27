using ContactList.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactSeeder
    {
        //aby odnieść sie do BD, wstrzykuję kontekst poprzez konstruktor do klasy
        private readonly ContactDbContext _dbContext;
        public ContactSeeder(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //funkcja do utworzenia początkowych danych
        public void Seed()
        {
            //sprawdzenie połączania do BD
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRole();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Contacts.Any())
                {
                    var contacts = GetContacts();
                    _dbContext.Contacts.AddRange(contacts);
                    _dbContext.SaveChanges();
                }
            }
        }
        //metoda zwracająca kolekcję kontaktów
        private IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jankowalski@gmail.com",
                    DateOfBirth = new DateTime(1991, 01, 01),
                    PhoneNumber = "111111111",
                    Category = "dom"
                },
                new Contact()
                {
                    FirstName = "Anna",
                    LastName = "Kowalska",
                    Email = "annakowalska@gmail.com",
                    DateOfBirth = new DateTime(1992, 02, 02),
                    PhoneNumber = "222222222",
                    Category = "dom"
                },
                new Contact()
                {
                    FirstName = "Monika",
                    LastName = "Nowak",
                    Email = "monikanowak@gmail.com",
                    DateOfBirth = new DateTime(1993, 03, 03),
                    PhoneNumber = "333333333",
                    Category = "służbowy"
                },
                new Contact()
                {
                    FirstName = "Jan",
                    LastName = "Nowak",
                    Email = "jannowak@gmail.com",
                    DateOfBirth = new DateTime(1994, 04, 04),
                    PhoneNumber = "444444444",
                    Category = "służbowy"
                },
                new Contact()
                {
                    FirstName = "Michał",
                    LastName = "Zalewski",
                    Email = "michałzalewski@gmail.com",
                    DateOfBirth = new DateTime(1995, 05, 25),
                    PhoneNumber = "555555555",
                    Category = "dom"
                },
            };
            return contacts;
        }
        private IEnumerable<Role> GetRole()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                }                
            };
            return roles;
        }

    }
}
