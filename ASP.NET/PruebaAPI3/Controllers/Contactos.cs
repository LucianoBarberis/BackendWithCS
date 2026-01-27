using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI3.Models;
using PruebaAPI3.Services;

namespace PruebaAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contactos : ControllerBase
    {
        private readonly IContactoService _contactoService;

        public Contactos(IContactoService contactoService) 
        {
            _contactoService = contactoService;
        }

        [HttpPost]
        public IActionResult CrearContacto([FromBody] Contacto contacto)
        {
            if (contacto == null || string.IsNullOrEmpty(contacto.Email))
            {
                return BadRequest("El contacto o el email no pueden ser nulos.");
            }
            if (!_contactoService.ValidarEmail(contacto.Email)) 
            {
                return BadRequest("Formato de email no soportado");
            }
            if (!_contactoService.ValidarName(contacto.Name)) 
            {
                return BadRequest("Nombre muy extenso");
            }

            _contactoService.Add(contacto);
            return Ok("Contacto agregado.");
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_contactoService.GetAll());
        }
    }
}
