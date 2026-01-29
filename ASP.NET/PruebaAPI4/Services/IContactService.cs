using Microsoft.AspNetCore.Mvc;
using PruebaAPI4.DTOs;
using PruebaAPI4.Models;

namespace PruebaAPI4.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactoReadDto>> GetAllContacts();
        Task<ContactoReadDto> GetContactById(int id);
        Task<ContactoReadDto> AddContact(ContactoCreateDto contacto);
        Task<ContactoReadDto> UpdateContact(ContactoUpdateDto contacto, int id);
        Task<Contacto> DeleteContact(int id);
    }
}
