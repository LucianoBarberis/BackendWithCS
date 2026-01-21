using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital
{
    public class Usuario(string name)
    {
        public string Name { get; } = name;
        public bool IsHolder = false;
    }
}
