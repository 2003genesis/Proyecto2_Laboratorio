using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
    class Cliente
    {
       



        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }


        public Cliente(string pnombre, string ptelefono, string pcorreo)
        {
          this.Nombre = pnombre;
          this.Telefono = ptelefono;
          this.Correo = pcorreo;
        }

        public Cliente()
        {
        }
    }
}

