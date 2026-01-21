using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeStok
{
    internal class Producto
    {
        private int _id;
        private string? _name;
        private string? _description;
        private float _price;
        private int _quantity;

        public Producto(string name, string desc, float price, int quantity) 
        {
            _id = _id + 1;
            _name = name;
            _description = desc;
            _price = price;
            _quantity = quantity;
        }

        public void showDetails()
        {
            Console.WriteLine($"id: {_id} | Nombre: {_name} | Descripcion: {_description} | Precio: {_price}");
        }
    }
}
