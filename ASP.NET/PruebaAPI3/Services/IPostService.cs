using PruebaAPI3.DTOs;

namespace PruebaAPI3.Services
{
    public interface IPostService
    {
        bool ValidarTitle (string title);
        public Task<IEnumerable<Post>> GetAll();
    }
}
