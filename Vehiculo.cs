using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proyecto2_Laboratorio.Objetos
{
    class Vehiculo
    {

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; } 
        public int IdCliente { get; set; } 

        public Vehiculo() { }

        public Vehiculo(int id, string placa, string marca, string modelo, int año, string color, string tipo, int idCliente)
        {
            Id = id;
            Placa = ValidarPlaca(placa);
            Marca = ValidarTexto(marca, "Marca");
            Modelo = ValidarTexto(modelo, "Modelo");
            Año = ValidarAño(año);
            Color = ValidarTexto(color, "Color");
            Tipo = ValidarTexto(tipo, "Tipo");
            IdCliente = idCliente;
        }

        private string ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("La placa no puede estar vacía.");
            if (placa.Length < 6 || placa.Length > 10)
                throw new ArgumentException("La placa debe tener entre 6 y 10 caracteres.");
            return placa.Trim();
        }

        private string ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{campo} no puede estar vacío.");
            return valor.Trim();
        }

        private int ValidarAño(int año)
        {
            if (año < 1900 || año > DateTime.Now.Year)
                throw new ArgumentException("El año del vehículo no es válido.");
            return año;
        }


    
    
    
        private static string rutaArchivo = @"C:\Users\hp\source\repos\Proyecto2_Laboratorio\Proyecto2_Laboratorio\bin\Debug\Vehiculoslist.Json";
        
            public static List<Vehiculo> CargarVehiculos()
        {
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "[]");
            }
            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Vehiculo>>(json) ?? new List<Vehiculo>();
        }

        public static void GuardarVehiculos(List<Vehiculo> vehiculos)
        {
            string json = JsonConvert.SerializeObject(vehiculos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static void AgregarVehiculo(Vehiculo vehiculo)
        {
            var vehiculos = CargarVehiculos();
            vehiculos.Add(vehiculo);
            GuardarVehiculos(vehiculos);
            Console.WriteLine("Vehículo agregado correctamente.");
        }

        public static void ListarVehiculos()
        {
            var vehiculos = CargarVehiculos();
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }
            foreach (var v in vehiculos)
            {
                Console.WriteLine($"ID: {v.Id} | Placa: {v.Placa} | Marca: {v.Marca} | Modelo: {v.Modelo} | Año: {v.Año} | Color: {v.Color} | Tipo: {v.Tipo} | Cliente ID: {v.IdCliente}");
            }
        }

        public static void BorrarVehiculo(int id)
        {
            var vehiculos = CargarVehiculos();
            var vehiculo = vehiculos.Find(v => v.Id == id);
            if (vehiculo != null)
            {
                vehiculos.Remove(vehiculo);
                GuardarVehiculos(vehiculos);
                Console.WriteLine($"Vehículo con ID {id} eliminado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un vehículo con ID {id}.");
            }
        }
        public static Vehiculo BuscarVehiculo(int id)
        {
            var vehiculos = CargarVehiculos();
            return vehiculos.Find(v => v.Id == id);
        }
    }
}


