using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI4.DTOs;
using PruebaAPI4.Services;
using System.ComponentModel.DataAnnotations;

namespace PruebaAPI4.Controllers
{
    [Route("api/agenda")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        private IValidator<ContactoUpdateDto> _validatorUpdate;
        private IValidator<ContactoCreateDto> _validatorAdd;
        public ContactController (IContactService contactService, 
                                  IValidator<ContactoCreateDto> validatorAdd,
                                  IValidator<ContactoUpdateDto> validatorUpdate)
        {
            _contactService = contactService;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
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
            var validationResult = _validatorAdd.Validate(contacto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var newContact = await _contactService.AddContact(contacto);

            return CreatedAtAction(nameof(GetById), new { id = newContact.ContactId }, newContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactoReadDto>> UpdateContacto([FromBody] ContactoUpdateDto contacto, int id) 
        {
            var validationResult = _validatorUpdate.Validate(contacto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var contactUpdated = await _contactService.UpdateContact(contacto, id);
            
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
