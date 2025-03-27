using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proyecto2_Laboratorio.Objetos
{
    class Repuesto
    {
       

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Repuesto() { }

        public Repuesto(int id, string nombre, string descripcion, decimal precio, int cantidad, string proveedor, DateTime fechaIngreso)
        {
            Id = id;
            Nombre = ValidarTexto(nombre, "Nombre");
            Descripcion = ValidarTexto(descripcion, "Descripción");
            Precio = ValidarPrecio(precio);
            Cantidad = ValidarCantidad(cantidad);
            Proveedor = ValidarTexto(proveedor, "Proveedor");
            FechaIngreso = fechaIngreso;
        }

        private string ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{campo} no puede estar vacío.");
            return valor.Trim();
        }

        private decimal ValidarPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            return precio;
        }

        private int ValidarCantidad(int cantidad)
        {
            if (cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");
            return cantidad;
        }

        private static string rutaArchivo = @"C:\Users\hp\source\repos\Proyecto2_Laboratorio\Proyecto2_Laboratorio\bin\Debug\RepuestosList.Json";
        public static List<Repuesto> CargarRepuestos()
        {
            if (!File.Exists(rutaArchivo)) return new List<Repuesto>();
            var json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Repuesto>>(json) ?? new List<Repuesto>();
        }

        public static void GuardarRepuestos(List<Repuesto> repuestos)
        {
            if (repuestos.Count > 100)
                throw new InvalidOperationException("No se pueden almacenar más de 100 repuestos.");
            Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));
            var json = JsonConvert.SerializeObject(repuestos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static void AgregarRepuesto(Repuesto repuesto)
        {
            var repuestos = CargarRepuestos();
            repuesto.Id = repuestos.Any() ? repuestos.Max(r => r.Id) + 1 : 1; // Evita ID duplicados
            repuestos.Add(repuesto);
            GuardarRepuestos(repuestos);
            Console.WriteLine("Repuesto agregado correctamente.");
        }

        public static void EliminarRepuesto(int id)
        {
            var repuestos = CargarRepuestos();
            var repuestoEliminar = repuestos.FirstOrDefault(r => r.Id == id);
            if (repuestoEliminar != null)
            {
                repuestos.Remove(repuestoEliminar);
                GuardarRepuestos(repuestos);
                Console.WriteLine($"Repuesto con ID {id} eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún repuesto con ID {id}.");
            }
        }

        public static void ListarRepuestos()
        {
            var repuestos = CargarRepuestos();
            if (repuestos.Count == 0)
            {
                Console.WriteLine("No hay repuestos registrados.");
                return;
            }

            Console.WriteLine("\n--- Lista de Repuestos ---");
            foreach (var repuesto in repuestos)
            {
                Console.WriteLine($"ID: {repuesto.Id}, Nombre: {repuesto.Nombre}, Precio: {repuesto.Precio}, Cantidad: {repuesto.Cantidad}, Proveedor: {repuesto.Proveedor}, Fecha Ingreso: {repuesto.FechaIngreso.ToShortDateString()}");
            }
        }
    }
}
