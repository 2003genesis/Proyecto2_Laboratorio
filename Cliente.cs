using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proyecto2_Laboratorio.Objetos
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string DocumentoIdentidad { get; set; }

        public Cliente() { }

        public Cliente(int id, string nombre, string apellido, string telefono, string correo, string direccion, string documentoIdentidad)
        {
            Id = id;
            Nombre = ValidarTexto(nombre, "Nombre");
            Apellido = ValidarTexto(apellido, "Apellido");
            Telefono = ValidarTelefono(telefono);
            Correo = ValidarCorreo(correo);
            Direccion = ValidarTexto(direccion, "Dirección");
            DocumentoIdentidad = ValidarDocumento(documentoIdentidad);
        }

        private string ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{campo} no puede estar vacío.");
            return valor.Trim();
        }

        private string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 8 || telefono.Length > 15)
                throw new ArgumentException("El teléfono debe tener entre 8 y 15 dígitos.");
            return telefono.Trim();
        }

        private string ValidarCorreo(string correo)
        {
            if (!correo.Contains("@") || !correo.Contains("."))
                throw new ArgumentException("Correo inválido.");
            return correo.Trim();
        }

        private string ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("El documento de identidad no puede estar vacío.");
            return documento.Trim();

        }
      
  
    
        public static string rutaArchivo = @"C:\Users\hp\source\repos\Proyecto2_Laboratorio\Proyecto2_Laboratorio\bin\Debug\ClientesList.Json";

        
        public static void AgregarCliente(Cliente cliente)
        {
            List<Cliente> clientes = CargarClientes();

            if (clientes.Exists(c => c.Id == cliente.Id || c.DocumentoIdentidad == cliente.DocumentoIdentidad))
            {
                Console.WriteLine("Error: Cliente con el mismo ID o Documento de Identidad ya existe.");
                return;
            }

            clientes.Add(cliente);
            GuardarClientes(clientes);
            Console.WriteLine("Cliente agregado correctamente.");
        }

   
        public static void ListarClientes()
        {
            List<Cliente> clientes = CargarClientes();
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre} {cliente.Apellido}, Teléfono: {cliente.Telefono}, Correo: {cliente.Correo}, Dirección: {cliente.Direccion}, Documento: {cliente.DocumentoIdentidad}");
            }
        }

       
        public static void BorrarCliente(int id)
        {
            List<Cliente> clientes = CargarClientes();
            Cliente clienteAEliminar = clientes.Find(c => c.Id == id);

            if (clienteAEliminar == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            clientes.Remove(clienteAEliminar);
            GuardarClientes(clientes);
            Console.WriteLine("Cliente eliminado correctamente.");
        }

       
        private static List<Cliente> CargarClientes()
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<Cliente>(); 
            }

            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }

        private static void GuardarClientes(List<Cliente> clientes)
        {
            string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static void BuscarCliente(int id)
        {
            List<Cliente> clientes = CargarClientes();
            Cliente clienteEncontrado = clientes.Find(c => c.Id == id);

            if (clienteEncontrado == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("==== CLIENTE ENCONTRADO ====");
            Console.WriteLine($"ID: {clienteEncontrado.Id}");
            Console.WriteLine($"Nombre: {clienteEncontrado.Nombre} {clienteEncontrado.Apellido}");
            Console.WriteLine($"Teléfono: {clienteEncontrado.Telefono}");
            Console.WriteLine($"Correo: {clienteEncontrado.Correo}");
            Console.WriteLine($"Dirección: {clienteEncontrado.Direccion}");
            Console.WriteLine($"Documento: {clienteEncontrado.DocumentoIdentidad}");
        }
    }
}

