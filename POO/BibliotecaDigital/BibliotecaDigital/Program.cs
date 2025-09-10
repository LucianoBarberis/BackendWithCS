using BibliotecaDigital;

Biblioteca biblioteca = new Biblioteca();
Libro libro = new Libro("Pedrito", "JuanPepe", "20/11/21", true);

libro.GiveBook();
int opc = 3;
do
{
    do
    {
        Console.Clear();
        Console.WriteLine("--- Bienvenido a la biblioteca ---");
        Console.WriteLine("1. Agregar un nuevo libro");
        Console.WriteLine("2. Prestar libro");
        Console.WriteLine("0. Salir");
        Console.WriteLine("Libros:");
        biblioteca.ListBooks();
        opc = Convert.ToInt32(Console.ReadLine());
    } while (opc > 3 || opc < 0);
    switch (opc)
    {
        case 0: Console.WriteLine("Saliendo...");break;
        case 1: AddBook(); break;
        case 2: ; break;
    }
}
while (opc != 0);

void AddBook()
{
    string name = LeerNoVacio("Ingrese el nombre del libro");
    string author = LeerNoVacio("Ingrese el nombnre del autor");
    string date = LeerNoVacio("Ingrese la fecha de creacion (../../..)");

    biblioteca.AddBook(new Libro(name, author, date, true));
}

string LeerNoVacio(string mensaje)

{
    string? input;
    do
    {
        Console.WriteLine(mensaje);
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("El valor no puede estar vacío. Intente nuevamente.");
        }
    } while (string.IsNullOrWhiteSpace(input));
    return input!;
}