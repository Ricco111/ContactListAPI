using AutoMapper;
using ContactList.Entities;
using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public class ContactServices : IContactServices
    {
        private readonly ContactDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactServices(ContactDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        //pobranie listy wszystkich kontaktów
        public IEnumerable<ContactDto> GetAll()
        {
            var contacts = _dbContext
                .Contacts
                .ToList();
            var contactsDtos = _mapper.Map<List<ContactDto>>(contacts);
            return contactsDtos;
        }


        //Pobranie jednego kontaktu po id

        public ContactDto GetById(int id)
        {
            var contact = _dbContext
               .Contacts
               .FirstOrDefault(r => r.Id == id);
            if (contact is null)
            {
                return null;
            }
            var result = _mapper.Map<ContactDto>(contact);
            return result;
        }

        //tworzenie nowego kontaktu
        public int Create(CreateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact.Id;
        }

        //usuwanie nowego kontaktu
        public bool Delete(int id)
        {
            var contact = _dbContext
               .Contacts
               .FirstOrDefault(r => r.Id == id);
            if (contact is null)
            {
                return false;
            }
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
            return true;
        }


        //edycja nowego kontaktu
        public bool Update(UpdateContactDto dto, int id)
        {
            var contact = _dbContext
               .Contacts
               .FirstOrDefault(r => r.Id == id);
            if (contact is null)
            {
                return false;
            }
            contact.FirstName = dto.FirstName;
            contact.LastName = dto.LastName;
            contact.Email = dto.Email;
            contact.DateOfBirth = dto.DateOfBirth;
            contact.PhoneNumber = dto.PhoneNumber;
            contact.Category = dto.Category;
            _dbContext.SaveChanges();
            return true;
        }

    }
}
