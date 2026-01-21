using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital
{
    internal class Biblioteca
    {
        private List<Libro> biblioteca = new List<Libro>();

        public void AddBook(Libro book)
        {
            biblioteca.Add(book);
            Console.WriteLine("El libro se añadio correctamente!");
        }

        public void RemoveBook(Libro book) 
        {
            if(!biblioteca.Contains(book))
            {
                Console.WriteLine("El libro no esta en la biblioteca...");
                return;
            }

            biblioteca.Remove(book);
        }

        public void GetAllBooks()
        {
            if(biblioteca.Count == 0) { return; }

            foreach (var book in biblioteca)
            {
                book.GetInfo();
            }
        }
    }
}
