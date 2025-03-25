using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Laboratorio.Objetos
{
     class ClientesList
    {
        public List<Cliente> clienteList { get; set; }
       
        public ClientesList()
        {
            clienteList = new List<Cliente>();
        }
        public void Add(Cliente pcliente)
        {
            clienteList.Add(pcliente);
        }

        public Cliente Search(string pnombre)
        {
            if (clienteList==null)
            {
                return null;
            }
            foreach (var cliente in clienteList) 
            {
                if (cliente.Nombre == pnombre)
                {
                    
                    return cliente;

                }
}
            return null;
    }

        public void Delete(string pnombre)
        {
            foreach (var cliente in clienteList) 
            {
                if (cliente.Nombre == pnombre)
                {
                    clienteList.Remove(cliente);
                    break;
                }
            }
        }

        public Cliente Update(Cliente pcliente)
        {
            if(clienteList==null)
            {
                return null;
            }
            foreach (var cliente in clienteList)
            {
                if (cliente.Nombre == pcliente.Nombre)
                {
                    cliente.Telefono = pcliente.Nombre;
                    cliente.Correo = pcliente.Correo;
                    return cliente;

                }
            }
            return null;




                }
        }
    }
