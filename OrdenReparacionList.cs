using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
   class OrdenReparacionList
    {


        public List<OrdenReparacion> ordenreparacionList { get; set; }

        public OrdenReparacionList()
        {
           ordenreparacionList = new List<OrdenReparacion>();
        }
        public void Add(OrdenReparacion pordenreparacion)
        {
            ordenreparacionList.Add(pordenreparacion);
        }

        public OrdenReparacion Search(string pid)
        {
            if (ordenreparacionList == null)
            {
                return null;
            }
            foreach (var ordenreparacion in ordenreparacionList)
            {
                if (ordenreparacion.ID == pid)
                {

                    return ordenreparacion;

                }
            }
            return null;
        }

        public void Delete(string pid)
        {
            foreach (var ordenreparacion in ordenreparacionList)
            {
                if (ordenreparacion.ID == pid)
                {
                    ordenreparacionList.Remove(ordenreparacion);
                    break;
                }
            }
        }

        public OrdenReparacion Update(OrdenReparacion pordenreparacion)
        {
            if (ordenreparacionList == null)
            {
                return null;
            }
            foreach (var ordenreparacion in ordenreparacionList)
            {
                if (ordenreparacion.ID == pordenreparacion.ID)
                {
                    ordenreparacion.Vehiculo= pordenreparacion.Vehiculo;
                    ordenreparacion.Cliente = pordenreparacion.Cliente;
                    ordenreparacion.Mecanico = pordenreparacion.Mecanico;
                    ordenreparacion.Descripcion = pordenreparacion.Descripcion;
                    ordenreparacion.Costo = pordenreparacion.Costo;
                    
                    return ordenreparacion;

                }
            }
            return null;

            

        }
    }
}

