using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Data;
using PruebaAPI4.Models;

namespace PruebaAPI4.Repository
{
    public class ContactRepository : IRepository<Contacto>
    {
        private AgendaContext _context;
        public ContactRepository(AgendaContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Contacto>> Get()
        {
            return await _context.Contactos.ToListAsync();
        }

        public async Task<Contacto> GetById(int id)
        {
            return await _context.Contactos.FindAsync(id);
        }

        public async Task Add(Contacto entity)
        {
            await _context.Contactos.AddAsync(entity);
        }

        public void Delete(Contacto entity)
        {
            _context.Contactos.Remove(entity);
        }
        public void Update(Contacto entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
