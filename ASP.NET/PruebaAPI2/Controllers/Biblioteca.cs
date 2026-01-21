using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI2.Models;

namespace PruebaAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Biblioteca : ControllerBase
    {
        private static BibliotecaModel _biblioteca = new BibliotecaModel();

        [HttpPost]
        public IActionResult AddLibro([FromBody] Libro libro)
        {
            return _biblioteca.AddLibro(libro);
        }

        [HttpGet]
        public List<Libro> GetLibro()
        {
            return _biblioteca.Libros;
        }

        [HttpGet("{id}")]
        public IActionResult GetLibrosById(int id)
        {
            Libro? libro = _biblioteca.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado");
            }
            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            Libro? libro = _biblioteca.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado");
            }
            _biblioteca.Libros.Remove(libro);
            return Ok("Libro eliminado correctamente");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLibro(int id, [FromBody] Libro updatedLibro)
        {
            Libro? libro = _biblioteca.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
            {
                return NotFound("Libro no encontrado");
            }
            libro.Titulo = updatedLibro.Titulo;
            libro.Autor = updatedLibro.Autor;
            libro.publicacion = updatedLibro.publicacion;
            return Ok("Libro actualizado correctamente");
        }
    }
}
