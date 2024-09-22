using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Fundamentos_de_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ingresar cantidad de estudiantes
                Console.Write("Ingrese la cantidad de estudiantes a registrar: ");
                int cantidadEstudiantes = int.Parse(Console.ReadLine());

                List<Estudiante> estudiantes = new List<Estudiante>();

                // Ciclo para ingresar datos de estudiantes
                for (int i = 0; i < cantidadEstudiantes; i++)
                {
                    Console.WriteLine($"\nIngrese los datos del estudiante {i + 1}:");

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Edad: ");
                    int edad = int.Parse(Console.ReadLine());

                    double promedio;
                    while (true) // Ciclo para asegurarse de que el promedio sea válido
                    {
                        try
                        {
                            Console.Write("Promedio: ");
                            string inputPromedio = Console.ReadLine();
                            inputPromedio = inputPromedio.Replace(',', '.');  // Reemplaza la coma por punto si es necesario
                            promedio = double.Parse(inputPromedio, CultureInfo.InvariantCulture);
                            break; // Si se parsea correctamente, salimos del ciclo
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("El formato del promedio no es válido. Por favor, ingrese un número válido.");
                        }
                    }

                    estudiantes.Add(new Estudiante(nombre, edad, promedio));
                }

                // Ciclo while para imprimir estudiantes con promedio >= 7.0 y marcar como reprobados si es < 7.0
                int contador = 0;
                while (contador < estudiantes.Count)
                {
                    if (estudiantes[contador].Promedio >= 7.0)
                    {
                        estudiantes[contador].MostrarInfo();
                    }
                    else
                    {
                        Console.WriteLine($"{estudiantes[contador].Nombre} está reprobado(a) con un promedio de {estudiantes[contador].Promedio}.");
                    }
                    contador++;
                }

                // Uso de un ciclo for para verificar si es mayor de edad
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    if (estudiantes[i].EsMayorDeEdad())
                    {
                        Console.WriteLine($"{estudiantes[i].Nombre} es mayor de edad.");
                    }
                    else
                    {
                        Console.WriteLine($"{estudiantes[i].Nombre} no es mayor de edad.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }

            // Espera una entrada para que no se cierre de inmediato
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    class Estudiante
    {
        // Propiedades
        public string Nombre { get; set; }
        private int Edad { get; set; }
        public double Promedio { get; set; }

        // Constructor
        public Estudiante(string nombre, int edad, double promedio)
        {
            Nombre = nombre;
            Edad = edad;
            Promedio = promedio;
        }

        // Método para verificar si el estudiante es mayor de edad
        public bool EsMayorDeEdad()
        {
            return Edad >= 18;
        }

        // Método para mostrar la información del estudiante
        public void MostrarInfo()
        {
            Console.WriteLine("La información del estudiante es: ");
            Console.WriteLine($"Nombre: {Nombre}, Promedio: {Promedio}");
        }
    }
}


