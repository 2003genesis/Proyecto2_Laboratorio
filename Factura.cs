using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto2_Laboratorio.Objetos;

namespace Proyecto2_Laboratorio.Objetos
{
 class Factura
    {
        
        public int Id { get; set; }
        public int IdOrdenReparacion { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
        public string ClienteNombre { get; set; }
        public string Estado { get; set; }

        public Factura() { }

        public Factura(int id, int idOrdenReparacion, decimal montoTotal, DateTime fecha, string metodoPago, string clienteNombre, string estado)
        {
            Id = id;
            IdOrdenReparacion = idOrdenReparacion;
            MontoTotal = montoTotal;
            Fecha = fecha;
            MetodoPago = ValidarTexto(metodoPago, "Método de Pago");
            ClienteNombre = ValidarTexto(clienteNombre, "Nombre del Cliente");
            Estado = ValidarTexto(estado, "Estado");
        }

        private string ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{campo} no puede estar vacío.");
            return valor.Trim();

        }
 
//menu

private static string rutaArchivo = @"C:\Users\hp\source\repos\Proyecto2_Laboratorio\Proyecto2_Laboratorio\bin\Debug\FacturaList.Json";
public static List<Factura> CargarFacturas()
{
    if (!File.Exists(rutaArchivo)) return new List<Factura>();
    var json = File.ReadAllText(rutaArchivo);
    return JsonConvert.DeserializeObject<List<Factura>>(json) ?? new List<Factura>();
}

public static void GuardarFacturas(List<Factura> facturas)
{
    if (facturas.Count > 100)
        throw new InvalidOperationException("No se pueden almacenar más de 100 facturas.");
    Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));
    var json = JsonConvert.SerializeObject(facturas, Formatting.Indented);
    File.WriteAllText(rutaArchivo, json);
}

public static void AgregarFactura(Factura factura)
{
    var facturas = CargarFacturas();
    factura.Id = facturas.Count + 1;
    facturas.Add(factura);
    GuardarFacturas(facturas);
}

public static void EliminarFactura(int id)
{
    var facturas = CargarFacturas();
    var factura = facturas.FirstOrDefault(f => f.Id == id);
    if (factura != null)
    {
        facturas.Remove(factura);
        GuardarFacturas(facturas);
    }
        }
        public static void BuscarFactura(int id)
        {
            var facturas = CargarFacturas();
            var factura = facturas.FirstOrDefault(f => f.Id == id);
            if (factura != null)
            {
                Console.WriteLine($"\nFactura encontrada:\nID: {factura.Id}\nCliente: {factura.ClienteNombre}\nMonto: {factura.MontoTotal}\nFecha: {factura.Fecha}\nEstado: {factura.Estado}");
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna factura con ID {id}.");
            }
        }
        public static void ListarFacturas()
        {
            var facturas = CargarFacturas();
            if (facturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            Console.WriteLine("\n--- Lista de Facturas ---");
            foreach (var factura in facturas)
            {
                Console.WriteLine($"ID: {factura.Id}, Cliente: {factura.ClienteNombre}, Monto: {factura.MontoTotal}, Fecha: {factura.Fecha}, Estado: {factura.Estado}");
            }
        }
    }
}



