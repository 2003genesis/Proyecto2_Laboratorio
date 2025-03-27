using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proyecto2_Laboratorio.Objetos
{
    class Mecanico
    {

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Especialidad { get; set; }
            public string Telefono { get; set; }
            public int AñosExperiencia { get; set; }
            public string Correo { get; set; }
            public string DocumentoIdentidad { get; set; }

            public Mecanico() { }

            public Mecanico(int id, string nombre, string apellido, string especialidad, string telefono, int añosExperiencia, string correo, string documentoIdentidad)
            {
                Id = id;
                Nombre = ValidarTexto(nombre, "Nombre");
                Apellido = ValidarTexto(apellido, "Apellido");
                Especialidad = ValidarTexto(especialidad, "Especialidad");
                Telefono = ValidarTelefono(telefono);
                AñosExperiencia = ValidarExperiencia(añosExperiencia);
                Correo = ValidarCorreo(correo);
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

            private int ValidarExperiencia(int años)
            {
                if (años < 0 || años > 50)
                    throw new ArgumentException("Los años de experiencia deben estar entre 0 y 50.");
                return años;
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

            
        
    
     private static string rutaArchivo = @"C:\Users\hp\source\repos\Proyecto2_Laboratorio\Proyecto2_Laboratorio\bin\Debug\MecanicoList.Json";

        public static List<Mecanico> CargarMecanicos()
        {
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "[]");
            }
            string json = File.ReadAllText(rutaArchivo);
            return JsonConvert.DeserializeObject<List<Mecanico>>(json) ?? new List<Mecanico>();
        }

        public static void GuardarMecanicos(List<Mecanico> mecanicos)
        {
            string json = JsonConvert.SerializeObject(mecanicos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static void AgregarMecanico(Mecanico mecanico)
        {
            var mecanicos = CargarMecanicos();
            mecanicos.Add(mecanico);
            GuardarMecanicos(mecanicos);
            Console.WriteLine("Mecánico agregado correctamente.");
        }

        public static void ListarMecanicos()
        {
            var mecanicos = CargarMecanicos();
            if (mecanicos.Count == 0)
            {
                Console.WriteLine("No hay mecánicos registrados.");
                return;
            }
            foreach (var m in mecanicos)
            {
                Console.WriteLine($"ID: {m.Id} | Nombre: {m.Nombre} {m.Apellido} | Especialidad: {m.Especialidad} | Teléfono: {m.Telefono} | Años de Experiencia: {m.AñosExperiencia} | Correo: {m.Correo} | Documento: {m.DocumentoIdentidad}");
            }
        }
    

 
        public static Mecanico BuscarMecanico(int id)
        {
            var mecanicos = CargarMecanicos();
            return mecanicos.Find(m => m.Id == id);
        }
        public static void BorrarMecanico(int id)
        {
            var mecanicos = CargarMecanicos();
            var mecanico = mecanicos.Find(m => m.Id == id);
            if (mecanico != null)
            {
                mecanicos.Remove(mecanico);
                GuardarMecanicos(mecanicos);
                Console.WriteLine($"Mecánico con ID {id} eliminado.");
            }
            else
            {
                Console.WriteLine($"No se encontró un mecánico con ID {id}.");
            }
        }
        

    }

    }
