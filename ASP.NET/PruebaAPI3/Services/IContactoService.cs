using PruebaAPI3.Models;

namespace PruebaAPI3.Services
{
    public interface IContactoService
    {
        bool ValidarEmail(string email);
        bool ValidarName(string name);
        void Add(Contacto contacto);
        List<Contacto> GetAll();
    }
}
