using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto2_Laboratorio.Objetos;

namespace Proyecto2_Laboratorio
{
     class Program
    {
       
        static void Main(string[] args)
        {
            Program objProgram = new Program();
            char seguir = 'N';
           
            do
            {
                Console.WriteLine("Seleccione una opcion.");
                Console.WriteLine("1. Agregar Cliente");
                Console.WriteLine("2. Agregar Vehiculo");
                Console.WriteLine("3. Agregar Mecanico");
                Console.WriteLine("4. Agregar Orden de Reparacion");
                Console.WriteLine("5. Agregar Factura");
                Console.WriteLine("6. Agregar Repuesto");
                Console.WriteLine("7. Listar Clientes");
                Console.WriteLine("8. Listar Vehiculos");
                Console.WriteLine("9. Listar Mecanico");
                Console.WriteLine("10.Listar Orden De Reparacion");
                Console.WriteLine("11.Listar Factura");
                Console.WriteLine("12.Listar Repuesto");
                Console.WriteLine("13.Buscar Cliente");
                Console.WriteLine("14.Buscar Vehiculo");
                Console.WriteLine("15.Buscar Mecanico");
                Console.WriteLine("16.Buscar Orden de Reparacion");
                Console.WriteLine("17.Buscar Factura");
                Console.WriteLine("18.Buscar Repuesto");
                Console.WriteLine("19.Eliminar Cliente");
                Console.WriteLine("20.Eliminar Vehiculo");
                Console.WriteLine("21.Eliminar Mecanico");
                Console.WriteLine("22.Elimar Orden de Repacion");
                Console.WriteLine("23.Eliminar Factura");
                Console.WriteLine("24.Elimar Repuesto");
                Console.WriteLine("25.Salir");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AgregarCliente();
                        break;

                    case "2":
                        AgregarVehiculo();
                        break;

                    case "3":
                        AgregarMecanico();
                        break;


                    case "4":
                        AgregarOrden();
                        break;

                    case "5":
                        AgregarFactura();
                        break;

                    case "6":
                        AgregarRepuesto();

                        break;

                    case "7":
                 
              Cliente.ListarClientes();
                        Console.WriteLine("\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case "8":
                        Vehiculo.ListarVehiculos();

                        break;
                     
                    case "9":
                        Mecanico.ListarMecanicos();
                        break;

                    case "10":
                        OrdenReparacion.ListarOrdenes();
                        break;

                    case "11":
                        Factura.ListarFacturas();
                        break;

                    case "12":
                        Repuesto.ListarRepuestos();
                        break;

                    case "13":
                        BuscarCliente();
                        break;

                    case "14":
                        BuscarVehiculo();
                        break;

                    case "15":
                        BuscarMecanico();
                        break;

                    case "16":
                        BuscarOrden();
                        break;

                    case "17":
                        BuscarFactura();
                        break;

                    case "18":
                        BuscarRepuesto();
                        break;

                    case "19":
                        EliminarCliente();
                        break;

                    case "20":
                        Console.Write("Ingrese el ID del vehículo a borrar: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                            Vehiculo.BorrarVehiculo(id);
                        else
                            Console.WriteLine("ID inválido.");
                        break;

                    case "21":
                        Mecanico.ListarMecanicos();
                        break;

                    case "22":
                        EliminarOrden();
                        break;

                    case "23":
                        EliminarFactura();
                        break;

                    case "24":
                        EliminarRepuesto();
                        break;

                    case "25":
                        ;
                        break;

                }
                Console.WriteLine("Si desea seguir, Tecle S");
                seguir = char.Parse(Console.ReadLine().Trim());
            } while (seguir.ToString().ToUpper() == "S");
            Console.ReadLine();


        }
        //PARTE DEL MENU PARA LO DE CLIENTES
        static void AgregarCliente()
        {
            Console.Clear();
            Console.WriteLine("==== AGREGAR CLIENTE ====");
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Correo: ");
            string correo = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Documento de Identidad: ");
            string documento = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(id, nombre, apellido, telefono, correo, direccion, documento);
            Cliente.AgregarCliente(nuevoCliente);
            Console.WriteLine("Cliente agregado");
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("==== ELIMINAR CLIENTE ====");
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente.BorrarCliente(id);

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        static void BuscarCliente()
        {
            Console.Clear();
            Console.WriteLine("==== BUSCAR CLIENTE ====");
            Console.Write("Ingrese el ID del cliente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente.BuscarCliente(id);

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }


        // PARTE DEL MENU PARA VEHICULOS
        
            static void AgregarVehiculo()
        {
            try
            {
                Console.Write("Ingrese ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Ingrese Placa: ");
                string placa = Console.ReadLine();

                Console.Write("Ingrese Marca: ");
                string marca = Console.ReadLine();

                Console.Write("Ingrese Modelo: ");
                string modelo = Console.ReadLine();

                Console.Write("Ingrese Año: ");
                int año = int.Parse(Console.ReadLine());

                Console.Write("Ingrese Color: ");
                string color = Console.ReadLine();

                Console.Write("Ingrese Tipo: ");
                string tipo = Console.ReadLine();

                Console.Write("Ingrese ID Cliente: ");
                int idCliente = int.Parse(Console.ReadLine());

                Vehiculo nuevoVehiculo = new Vehiculo(id, placa, marca, modelo, año, color, tipo, idCliente);
                Vehiculo.AgregarVehiculo(nuevoVehiculo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void BuscarVehiculo()
            {
                Console.Write("Ingrese el ID del vehículo a buscar: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Vehiculo vehiculo = Vehiculo.BuscarVehiculo(id);
                    if (vehiculo != null)
                    {
                        Console.WriteLine($"\nVehículo encontrado:\nID: {vehiculo.Id} | Placa: {vehiculo.Placa} | Marca: {vehiculo.Marca} | Modelo: {vehiculo.Modelo} | Año: {vehiculo.Año} | Color: {vehiculo.Color} | Tipo: {vehiculo.Tipo} | Cliente ID: {vehiculo.IdCliente}");
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }
        //LO DEL MENU PARA MECANICO
        static void AgregarMecanico()
        {
        
                try
                {
                    Console.Write("Ingrese ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.Write("Ingrese Especialidad: ");
                    string especialidad = Console.ReadLine();

                    Console.Write("Ingrese Teléfono: ");
                    string telefono = Console.ReadLine();

                    Console.Write("Ingrese Años de Experiencia: ");
                    int años = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese Correo: ");
                    string correo = Console.ReadLine();

                    Console.Write("Ingrese Documento de Identidad: ");
                    string documento = Console.ReadLine();

                    Mecanico nuevoMecanico = new Mecanico(id, nombre, apellido, especialidad, telefono, años, correo, documento);
                    Mecanico.AgregarMecanico(nuevoMecanico);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        

        static void BuscarMecanico()
            {
                Console.Write("Ingrese el ID del mecánico a buscar: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Mecanico mecanico = Mecanico.BuscarMecanico(id);
                    if (mecanico != null)
                    {
                        Console.WriteLine($"\nMecánico encontrado:\nID: {mecanico.Id} | Nombre: {mecanico.Nombre} {mecanico.Apellido} | Especialidad: {mecanico.Especialidad} | Teléfono: {mecanico.Telefono} | Años de Experiencia: {mecanico.AñosExperiencia} | Correo: {mecanico.Correo} | Documento: {mecanico.DocumentoIdentidad}");
                    }
                    else
                    {
                        Console.WriteLine("Mecánico no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }
        //LO DEL MENU PARA FACTURA

        static void AgregarFactura()
        {
            Console.Write("Ingrese el ID de la orden de reparación: ");
            int idOrden = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el monto total: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el método de pago: ");
            string metodoPago = Console.ReadLine();

            Console.Write("Ingrese el nombre del cliente: ");
            string clienteNombre = Console.ReadLine();

            Console.Write("Ingrese el estado de la factura: ");
            string estado = Console.ReadLine();

            Factura nuevaFactura = new Factura(0, idOrden, monto, fecha, metodoPago, clienteNombre, estado);
            Factura.AgregarFactura(nuevaFactura);
        }

        static void EliminarFactura()
        {
            Console.Write("Ingrese el ID de la factura a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Factura.EliminarFactura(id);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        static void BuscarFactura()
        {
            Console.Write("Ingrese el ID de la factura a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Factura.BuscarFactura(id);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }
        //LO DEL MENU PARA ORDEN REPARACION
        static void AgregarOrden()
        {
            Console.Write("Ingrese el ID del vehículo: ");
            int idVehiculo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el ID del mecánico: ");
            int idMecanico = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el costo de la reparación: ");
            decimal costo = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese la descripción de la reparación: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese el estado de la orden (Pendiente/En proceso/Completada): ");
            string estado = Console.ReadLine();

            OrdenReparacion nuevaOrden = new OrdenReparacion(0, idVehiculo, idMecanico, fecha, costo, descripcion, estado);
            OrdenReparacion.AgregarOrden(nuevaOrden);
        }

        static void EliminarOrden()
        {
            Console.Write("Ingrese el ID de la orden de reparación a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                OrdenReparacion.EliminarOrden(id);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        static void BuscarOrden()
        {
            Console.Write("Ingrese el ID de la orden de reparación a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                OrdenReparacion.BuscarOrden(id);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        //LO DEL MENU PARA REPUESTO

        static void AgregarRepuesto()
        {
            Console.Write("Ingrese el nombre del repuesto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la descripción del repuesto: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese el precio del repuesto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad disponible: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el proveedor del repuesto: ");
            string proveedor = Console.ReadLine();

            Console.Write("Ingrese la fecha de ingreso (YYYY-MM-DD): ");
            DateTime fechaIngreso = DateTime.Parse(Console.ReadLine());

            Repuesto nuevoRepuesto = new Repuesto(0, nombre, descripcion, precio, cantidad, proveedor, fechaIngreso);
            Repuesto.AgregarRepuesto(nuevoRepuesto);
        }

        static void EliminarRepuesto()
        {
            Console.Write("Ingrese el ID del repuesto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Repuesto.EliminarRepuesto(id);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        static void BuscarRepuesto()
        {
            Console.Write("Ingrese el ID del repuesto a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var repuestos = Repuesto.CargarRepuestos();
                var repuesto = repuestos.FirstOrDefault(r => r.Id == id);
                if (repuesto != null)
                {
                    Console.WriteLine($"\nRepuesto encontrado:\nID: {repuesto.Id}\nNombre: {repuesto.Nombre}\nDescripción: {repuesto.Descripcion}\nPrecio: {repuesto.Precio}\nCantidad: {repuesto.Cantidad}\nProveedor: {repuesto.Proveedor}\nFecha Ingreso: {repuesto.FechaIngreso.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("No se encontró el repuesto.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }
    }
}


    
 
    













