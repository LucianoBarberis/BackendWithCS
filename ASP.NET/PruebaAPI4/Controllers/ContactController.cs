using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PruebaAPI4.DTOs;
using PruebaAPI4.Services;

namespace PruebaAPI4.Controllers
{
    [Route("api/agenda")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        public ContactController (IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactoReadDto>> GetAll()
        {
            return await _contactService.GetAllContacts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoReadDto>> GetById(int id)
        {
            var contacto = await _contactService.GetContactById(id);
            if (contacto == null)
                return NotFound();

            return Ok(contacto);
        }
        [HttpPost]
        public async Task<ActionResult<ContactoCreateDto>> AddContacto(ContactoCreateDto contacto)
        {
            var newContact = await _contactService.AddContact(contacto);
            return CreatedAtAction(nameof(GetById), new { id = newContact.ContactId }, newContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactoReadDto>> UpdateContacto([FromBody] ContactoUpdateDto contacto, int id) 
        {
            var contactUpdated = await _contactService.UpdateContact(contacto, id);
            if(contactUpdated == null) {  return NotFound(); }
            return Ok(contactUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id) 
        {
            if(await _contactService.DeleteContact(id) == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
