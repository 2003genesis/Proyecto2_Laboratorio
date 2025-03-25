using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
     class OrdenReparacion
    {
        public string ID { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public Mecanico Mecanico { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public bool Finalizado { get; set; }

        public OrdenReparacion(string pid, Vehiculo pvehiculo, Cliente pcliente, Mecanico pmecanico, string pdescripcion, double pcosto)
        {
            ID = pid;
            Vehiculo = pvehiculo;
            Cliente = pcliente;
            Mecanico = pmecanico;
            Descripcion = pdescripcion;
            Costo = pcosto;
            Finalizado = false;
        }

        public OrdenReparacion()
        {
           
        }
    }
}
