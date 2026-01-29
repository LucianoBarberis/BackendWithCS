using Microsoft.EntityFrameworkCore;
using PruebaAPI4.Models;

namespace PruebaAPI4.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) 
        { }

        public DbSet<Contacto> Contactos { get; set; }
    }
}
