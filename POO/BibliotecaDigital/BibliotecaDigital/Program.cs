using BibliotecaDigital;
using System.Runtime.CompilerServices;

Libro libro1 = new("El Principito", "Antoine de Saint-Exupéry");
Libro libro2 = new("Atomic Habits", "James Clear");

Usuario usuario1 = new("Luciano");

Biblioteca biblioteca = new Biblioteca();

biblioteca.AddBook(libro1);
biblioteca.AddBook(libro2);
line();
biblioteca.GetAllBooks();
line();
libro2.GiveBook(usuario1);
line();
biblioteca.GetAllBooks();

static void line()
{
    Console.WriteLine("_______________________________________");
}