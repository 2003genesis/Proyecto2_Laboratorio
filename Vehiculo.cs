using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
    internal class Vehiculo
    {

    public string Placa { get; set; }
        public string Marca { get; set; }
        public int Año { get; set; }
        public double Kilometraje { get; set; }
        public string Propietario { get; set; }
        public string Color { get; set; }
        public bool Estado { get; set; } 

        
        public Vehiculo(string placa, string marca, int año, double kilometraje, string propietario, string color)
        {
            Placa = placa;
            Marca = marca;
            Año = año;
            Kilometraje = kilometraje;
            Propietario = propietario;
            Color = color;
            Estado = true;
        }

        public Vehiculo()
        {
        }
}
}

