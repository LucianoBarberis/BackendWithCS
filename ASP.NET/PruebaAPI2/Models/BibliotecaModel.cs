using Microsoft.AspNetCore.Mvc;

namespace PruebaAPI2.Models
{
    public class BibliotecaModel
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();

        public IActionResult AddLibro(Libro libro)
        {
            bool exists = Libros.Any(l => l.Id == libro.Id);
            if (exists)
            {
                return new BadRequestObjectResult("El libro con este ID ya existe.");
            }else
            {
                Libros.Add(libro);
                return new OkObjectResult("Libro agregado exitosamente.");
            }
        }
    }
}
