using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
    class VehiculoList
    {
        public List<Vehiculo> vehiculolist { get; set; }

        public VehiculoList()
        {
            vehiculolist = new List<Vehiculo>();
        }

        public void Add(Vehiculo vehiculo)
        {
            vehiculolist.Add(vehiculo);
        }

        public Vehiculo Search(string placa)
        {
            if (vehiculolist == null)
            {
                return null;
            }

            foreach (var vehiculo in vehiculolist)
            {
                if (vehiculo.Placa == placa)
                {
                    return vehiculo;
                }
            }

            return null;
        }

        public void Delete(string placa)
        {
            foreach (var vehiculo in vehiculolist)
            {
                if (vehiculo.Placa == placa)
                {
                    vehiculolist.Remove(vehiculo);
                    break;
                }
            }

        }

        public Vehiculo Update(Vehiculo vehiculo)
        {
            if (vehiculolist == null)
            {
                return null;
            }

            foreach (var item in vehiculolist)
            {
                if (vehiculo.Placa == vehiculo.Placa)
                {
                    vehiculo.Marca = vehiculo.Marca;
                    vehiculo.Año = vehiculo.Año;
                    vehiculo.Kilometraje = vehiculo.Kilometraje;
                    vehiculo.Propietario = vehiculo.Propietario;
                    vehiculo.Color = vehiculo.Color;
                    vehiculo.Estado = vehiculo.Estado;

                    return vehiculo;
                }
            }

            return null;
        }
        }

       
        }
 
