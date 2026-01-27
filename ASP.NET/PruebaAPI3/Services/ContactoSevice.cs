using PruebaAPI3.Controllers;
using PruebaAPI3.Models;

namespace PruebaAPI3.Services
{
    public class ContactoSevice : IContactoService
    {
        private readonly List<Contacto> _contactos = new();
        public bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public void Add(Contacto contacto)
        {
            if (contacto == null) return;
            contacto.Id = _contactos.Count > 0 ? _contactos.Max(c => c.Id) + 1 : 1;
            _contactos.Add(contacto);
        }
        public List<Contacto> GetAll()
        {
            return _contactos;
        }
        public bool ValidarName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length > 20) return false;
            return true;
        }
    }
}
