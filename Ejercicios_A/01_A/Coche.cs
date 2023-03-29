using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_A
{
    internal class Coche
    {
        public float Km {get;set;}
        public float Litros { get;set;}

        public float Consumo() 
        {
            return this.Litros / this.Km;
        }
    }
}
