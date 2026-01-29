using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Data;
using PruebaAPI4.DTOs;
using PruebaAPI4.Models;

namespace PruebaAPI4.Services
{
    public class ContactSevice : IContactService
    {
        private AgendaContext _context;
        public ContactSevice(AgendaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactoReadDto>> GetAllContacts()
        {
            return await _context.Contactos.Select(c => new ContactoReadDto
            {
                ContactId = c.ContactId,
                Email = c.Mail,
                Name = c.Name,
                Phone = c.Phone
            }).ToListAsync();
        }
        public async Task<ContactoReadDto> GetContactById(int id) 
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null) 
            {
                return null;
            }
            var contactoDto = new ContactoReadDto
            {
                ContactId = contacto.ContactId,
                Email = contacto.Mail,
                Name = contacto.Name,
                Phone = contacto.Phone
            };
            return contactoDto;
        }

        public async Task<ContactoReadDto> AddContact(ContactoCreateDto contacto)
        {
            var newContact = new Contacto
            {
                Mail = contacto.Email,
                Name = contacto.Name,
                Phone = contacto.Phone
            };
            await _context.Contactos.AddAsync(newContact);
            await _context.SaveChangesAsync();

            var ContactoDto = new ContactoReadDto
            {
                ContactId= newContact.ContactId,
                Email = newContact.Mail,
                Name = newContact.Name,
                Phone = newContact.Phone,
            };

            return ContactoDto;
        }

        public async Task<ContactoReadDto> UpdateContact(ContactoUpdateDto DataToUpdate, int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return null;
            }
            
            contacto.Phone = DataToUpdate.Phone;
            contacto.Name = DataToUpdate.Name;
            contacto.Mail = DataToUpdate.Email;
            await _context.SaveChangesAsync();

            return new ContactoReadDto 
            {
                Phone = DataToUpdate.Phone,
                Name = DataToUpdate.Name,
                Email = DataToUpdate.Email,
                ContactId = id,
            };
        }

        public async Task<Contacto> DeleteContact(int id)
        {
            var ContactToDelete = await _context.Contactos.FindAsync(id);
            if (ContactToDelete == null) 
            {
                return null;
            }

            _context.Contactos.Remove(ContactToDelete);
            await _context.SaveChangesAsync();

            return ContactToDelete;
        }
    }
}
