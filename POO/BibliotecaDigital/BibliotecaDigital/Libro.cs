using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital
{
    public class Libro(string bookName, string authorName)
    {
        private string _bookName = bookName;
        private string _author = authorName;
        private bool _available = true;
        private Usuario? _atualHolder = null;

        public void GiveBook(Usuario usuario)
        {
            if (_available == false) 
            {
                Console.WriteLine("Este libro ya esta prestado");
                return;
            }

            if (usuario.IsHolder) 
            {
                Console.WriteLine("El usuario ya el poseedor de un libro...");
                return;
            }

            _atualHolder = usuario;
            _available = false;
            usuario.IsHolder = true;

            Console.WriteLine($"El nuevo poseedor es {_atualHolder.Name} y el estado del libro cambio a {_available}");
        }

        public void ReturnBook()
        {
            if (_available) 
            {
                Console.WriteLine("Este libro ya esta en la biblioteca");
                return;
            }

            if (_atualHolder == null)
            {
                Console.WriteLine("Este libro ya esta en la biblioteca");
                return;
            }

            _atualHolder.IsHolder = false;
            _available = true;
            _atualHolder = null;

            Console.WriteLine($"El libro nuevamente es en la biblioteca y el estado del libro cambio a {_available}");
        }

        public void GetInfo()
        {
            Console.WriteLine("\nNombre del Libro: " + _bookName);
            Console.WriteLine("Autor: " + _author);
            Console.WriteLine("Estado del libro: " + (_available ? "Disponible" : "Prestado"));
            Console.WriteLine("Actual poseedor: " + (_available ? "Biblioteca" : _atualHolder.Name));
        }
    }
}
