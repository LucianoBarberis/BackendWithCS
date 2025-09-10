using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital
{
    public class Libro
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicatedAt { get; set; }
        public bool State { get; set; } = true;

        public Libro(string title, string author, string publicatedAt, bool state)
        {
            Title = title;
            Author = author;
            PublicatedAt = publicatedAt;
        }

        public void ReturnBook()
        {
            if (State == false)
            {
                State = true;
                Console.WriteLine("El Libro fue devuelto a la biblioteca");
            }
            else
            {
                Console.WriteLine("El Libro ya esta en la biblioteca");
            }
        }

        public void GiveBook()
        {
            if (State == true)
            {
                State = false;
                Console.WriteLine($"El Libro fue prestado");
            }else
            {
                Console.WriteLine("El libro ya esta siendo usado por otra persona...");
            }
        }
    }
}
