using AutoMapper;
using ContactList.Entities;
using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<CreateContactDto, Contact>();
        }
    }
}
