using ContactList.Models;
using System.Collections.Generic;

namespace ContactList.Services
{
    public interface IContactServices
    {
        int Create(CreateContactDto dto);
        IEnumerable<ContactDto> GetAll();
        ContactDto GetById(int id);
        bool Delete(int id);
        bool Update(UpdateContactDto dto, int id);
    }
}