using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital
{
    internal class Biblioteca
    {
        private List<Libro> libros = new List<Libro> ();
        
        public void AddBook (Libro libro)
        {
            libros.Add (libro);
        }

        public void ListBooks()
        {
            foreach (var libro in libros)
            {
                Console.WriteLine($"{libro.Title} - {(libro.State == true ? "Disponible" : "En Uso...")}");
            }
        }
    }
}
