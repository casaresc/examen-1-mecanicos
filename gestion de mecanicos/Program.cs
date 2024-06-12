using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_de_mecanicos
{
    namespace TallerMecanico
    {
        class Program
        {
            static void Main(string[] args)
            {
                //lista de mecánicos
                List<Mecanico> mecanicos = new List<Mecanico>
            {
                new Mecanico("Juan", "Motor", new Disponibilidad("Lunes", 9, 17)),
                new Mecanico("Ana", "Frenos", new Disponibilidad("Martes", 8, 16)),
                new Mecanico("Pedro", "Transmisión", new Disponibilidad("Lunes", 10, 18))
            };

                Tarea tarea = new Tarea("Reparación de motor", "Motor", 3);

                string resultado = EncontrarMecanico(mecanicos, tarea);
                Console.WriteLine(resultado);

                EliminarMecanico(mecanicos, "Ana");

                resultado = EncontrarMecanico(mecanicos, tarea);
                Console.WriteLine(resultado);
            }

            public static string EncontrarMecanico(List<Mecanico> mecanicos, Tarea tarea)
            {
                foreach (var mecanico in mecanicos)
                {
                    if (mecanico.Especialidad == tarea.EspecialidadRequerida)
                    {
                        if (mecanico.Disponibilidad.HorasFin - mecanico.Disponibilidad.HorasInicio >= tarea.Duracion)
                        {
                            return $"{mecanico.Nombre} puede realizar la tarea '{tarea.Descripcion}' el {mecanico.Disponibilidad.Dia} entre {mecanico.Disponibilidad.HorasInicio}:00 y {mecanico.Disponibilidad.HorasFin}:00";
                        }
                    }
                }
                return "No hay mecánico disponible para esta tarea.";
            }

            public static void EliminarMecanico(List<Mecanico> mecanicos, string nombre)
            {
                Mecanico mecanicoAEliminar = mecanicos.Find(m => m.Nombre == nombre);
                if (mecanicoAEliminar != null)
                {
                    mecanicos.Remove(mecanicoAEliminar);
                    Console.WriteLine($"Mecánico {nombre} eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine($"Mecánico {nombre} no encontrado.");
                }
            }
        }

        public class Mecanico
        {
            public string Nombre { get; set; }
            public string Especialidad { get; set; }
            public Disponibilidad Disponibilidad { get; set; }

            public Mecanico(string nombre, string especialidad, Disponibilidad disponibilidad)
            {
                Nombre = nombre;
                Especialidad = especialidad;
                Disponibilidad = disponibilidad;
            }
        }

        public class Disponibilidad
        {
            public string Dia { get; set; }
            public int HorasInicio { get; set; }
            public int HorasFin { get; set; }

            public Disponibilidad(string dia, int horasInicio, int horasFin)
            {
                Dia = dia;
                HorasInicio = horasInicio;
                HorasFin = horasFin;
            }
        }

        public class Tarea
        {
            public string Descripcion { get; set; }
            public string EspecialidadRequerida { get; set; }
            public int Duracion { get; set; }

            public Tarea(string descripcion, string especialidadRequerida, int duracion)
            {
                Descripcion = descripcion;
                EspecialidadRequerida = especialidadRequerida;
                Duracion = duracion;
            }
        }
    }
}
