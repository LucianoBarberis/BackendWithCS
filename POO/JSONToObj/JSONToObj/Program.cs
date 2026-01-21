using System.Text.Json;

var prod1 = new Product("GeForce 3090", 670);
var prod2 = new Product("Intel I7 6400", 880);

var Almacen1 = new Almacen<Product>();

Almacen1.AddItem(prod1);
Almacen1.AddItem(prod2);

Console.WriteLine(Almacen1.GetItem(1).Name);
Console.WriteLine(Almacen1.GetAll().Count);

var sale1 = new Sale(Almacen1.GetItem(1).Price + Almacen1.GetItem(0).Price, (Almacen1.GetItem(1).Name + " & " + Almacen1.GetItem(0).Name));
sale1.GetInfo();

var sale2 = new SaleWithTax(Almacen1.GetItem(1).Price + Almacen1.GetItem(0).Price, (Almacen1.GetItem(1).Name + " & " + Almacen1.GetItem(0).Name));
sale2.GetInfo();

var json = JsonSerializer.Serialize(prod2);

Console.WriteLine(json);

Product JsonDeser = JsonSerializer.Deserialize<Product>(json);

Console.WriteLine($"{JsonDeser.Name} & {JsonDeser.Price}");

Func<decimal, decimal> applyTax = total => (total * 0.21M) + total;
Console.WriteLine(applyTax(prod1.Price));

var caros = from p in Almacen1.GetAll()
            where p.Price > 700
            select p;
Console.WriteLine("Productos caros:");
foreach (var p in caros)
    Console.WriteLine(p.Name);

interface ISale
{
    decimal Total { get; set; }
}

class Sale(decimal amount, string detalle) : ISale 
{
    public decimal Total { get; set; } = amount;
    private string Detaill = detalle;

    public virtual void GetInfo()
    {
        Console.WriteLine($"El Total de la venta de {Detaill} es {Total}");
    }
}

class SaleWithTax(decimal amount, string detalle) : Sale(amount, detalle)
{
    public decimal Total { get; set; } = amount;
    private string Detaill = detalle;
    private decimal TotalWithTax = amount + (amount * 0.21M);

    public override void GetInfo()
    {
        Console.WriteLine($"El Total de la venta de {Detaill} con impuestos es {TotalWithTax}; sin impuestos {Total} ");
    }
}

class Product (string name, decimal price)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
}

public class Almacen<T>
{
    private List<T> _Productos = new List<T>();

    public void AddItem(T item) => _Productos.Add(item);
    public T GetItem(int index) => _Productos[index];
    public List<T> GetAll() => _Productos;
}