using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Data;
using PruebaAPI4.DTOs;
using PruebaAPI4.Models;
using PruebaAPI4.Repository;
using PruebaAPI4.Validations;

namespace PruebaAPI4.Services
{
    public class ContactSevice : IContactService
    {


        private IRepository<Contacto> _contactRepository;

        public ContactSevice(IRepository<Contacto> repository)
        {
            _contactRepository = repository;
        }
        public async Task<IEnumerable<ContactoReadDto>> GetAllContacts()
        {
            var contacts = await _contactRepository.Get();
            return contacts.Select(contact => new ContactoReadDto
            {
                Name = contact.Name,
                Email = contact.Mail,
                Phone = contact.Phone,
                ContactId = contact.ContactId,
            });
        }
        public async Task<ContactoReadDto> GetContactById(int id) 
        {
            var contacto = await _contactRepository.GetById(id);
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
            await _contactRepository.Add(newContact);
            await _contactRepository.Save();

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
            var contacto = await _contactRepository.GetById(id);
            if (contacto == null)
            {
                return null;
            }
            
            contacto.Phone = DataToUpdate.Phone;
            contacto.Name = DataToUpdate.Name;
            contacto.Mail = DataToUpdate.Email;
            _contactRepository.Update(contacto);
            await _contactRepository.Save();

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
            var ContactToDelete = await _contactRepository.GetById(id);
            if (ContactToDelete == null) 
            {
                return null;
            }

            _contactRepository.Delete(ContactToDelete);
            await _contactRepository.Save();

            return ContactToDelete;
        }
    }
}
