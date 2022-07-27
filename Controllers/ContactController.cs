using AutoMapper;
using ContactList.Entities;
using ContactList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Services;
using Microsoft.AspNetCore.Authorization;

namespace ContactList.Controllers
{

    //Kontroler obsługujący działania na kontaktach CRUD
    [Route("api/contact")]
    [Authorize] //wymagana autoryzacja aby obsługiwać endpointy
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactService;

        public ContactController(IContactServices contactServices)
        {
            _contactService = contactServices;
        }





        [HttpGet]
        [AllowAnonymous] //zezwolenie na obugę bez autoryzacji tylko tego endpointu
        //pobranie listy wszystkich kontaktów
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            var contactsDtos = _contactService.GetAll();
            return Ok(contactsDtos);
        }



        [HttpGet("{id}")]
        //Pobranie jednego kontaktu po id
        public ActionResult<Contact> Get([FromRoute] int id)
        {
            var contact = _contactService.GetById(id);
            if(contact is null)
            {
                return NotFound();
            }
            return Ok(contact);
        }


        //tworzenie nowego kontaktu
        [HttpPost]
        public ActionResult CreateContact([FromBody]CreateContactDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id =_contactService.Create(dto);

            return Created($"/api/contact/{id}", "KONTAKT UTWORZONY");
;       }


        //usuwanie kontaktu
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _contactService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        //edycja kontaktu
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateContactDto dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _contactService.Update(dto, id);
            if(!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
