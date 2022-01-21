using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    class Program
    {

        private static string[] Opciones =  { "Registrar Personas", "Listar Personas", "Listar personas mayores",
                                          "Listar descendente por edad", 
                                          "Listar ascendente por edad - LINQ", 
                                          "Listar personas mayores - LINQ",
                                          "Listar personas mayores - LINQ 2",
                                          "Listar ascendente por edad - LINQ 2",
                                            "Salir"};

        private const int MAXIMO = 3;
        private static Persona[] Personas;

        static void Main(string[] args)
        {
            Personas = new Persona[MAXIMO];
            int op;

            do
            {
                op = Funciones.LeerMenu("MENU PRINCIPAL", Opciones, "Opcion : ", "Opción no válida");
                switch (op)
                {
                    case 1: LeerPersonas();
                        break;
                    case 2: PresentarPersonas();
                        break;
                    case 3: PresentarMayores();
                        break;
                    case 4: PresentarOrdenadoEdad();
                        break;
                    case 5: PresentarOrdenadoEdadLinq();
                        break;
                    case 6: PresentarMayoresLinq();
                        break;
                    case 7: PresentarMayoresLinq2();
                        break;
                    case 8: PresentarOrdenadoEdadLinq2();
                        break;
                }
            } while (op < Opciones.Length );
        }

        private static void PresentarMayoresLinq()
        {
            IEnumerable<Persona> Mayores;

            Mayores = Personas.Where(per => per.Edad >= 18);
            foreach (Persona per in Mayores)
            {
                Console.WriteLine(per.NombreCompleto + "(" + per.Edad + ")");
            }
            Console.ReadLine();
        }

        private static void PresentarMayoresLinq2()
        {
            IEnumerable<Persona> Mayores;

            Mayores = from Per in Personas
                      where Per.Edad >= 18
                      select Per;

            foreach (Persona per in Mayores)
            {
                Console.WriteLine(per.NombreCompleto + "(" + per.Edad + ")");
            }
            Console.ReadLine();
        }

        private static void PresentarOrdenadoEdadLinq()
        {
            IEnumerable<Persona> Ordenados;

            Ordenados = Personas.OrderBy(per => per.Edad);

            ListarPersonasEnumerado(Ordenados);
        }

        private static void ListarPersonasEnumerado(IEnumerable<Persona> Ordenados)
        {
            foreach (Persona per in Ordenados)
            {
                Console.WriteLine(per.NombreCompleto + "(" + per.Edad + ")");
            }
            Console.ReadLine();
        }

        private static void PresentarOrdenadoEdadLinq2()
        {
            IEnumerable<Persona> Ordenados;

            Ordenados = from Per in Personas
                        orderby Per.Edad
                        select Per;
            
            ListarPersonasEnumerado(Ordenados);
        }

        private static void PresentarOrdenadoEdad()
        {
            OrdenarPersonas();
            PresentarPersonas();
        }

        private static void OrdenarPersonas()
        {
            Persona aux;

            for (int i = 0; i < Personas.Length - 1; i++)
            {
                for (int j = i + 1; j < Personas.Length; j++)
                {
                    if (Personas[i].Edad < Personas[j].Edad)
                    {
                        aux = Personas[i];
                        Personas[i] = Personas[j];
                        Personas[j] = aux;
                    }
                }
            }
        }

        private static void PresentarMayores()
        {
            Console.WriteLine("LISTADO DE MAYORES DE EDAD");
            foreach (Persona Per in Personas)
            {
                if (Per.MayorEdad == true)
                {
                    Console.WriteLine(Per.NombreCompleto);
                }
            }
        }

        private static void PresentarPersonas()
        {
            string msje;

            for (int i = 0; i < MAXIMO; i++)
            {
                msje = Personas[i].NombreCompleto + "(" + Personas[i].Edad + ")" ;
                msje += Personas[i].MayorEdad == true ? " es mayor de edad " : " es menor de edad";

                Console.WriteLine((i + 1) + ".-" + msje);
            }
        }

        private static void LeerPersonas()
        {
            Persona Per = null;

            for (int i = 0; i < MAXIMO; i++)
            {
                Per = new Persona();
                Console.Write("Nombre : ");
                Per.Nombres = Console.ReadLine();
                Per.Edad = Funciones.LeerEntero("Edad : ", 0, 90, "Edad no valida");
                Personas[i] = Per;
            }
            //Per.NombreCompleto = "Ana Carlita Paola Leon Rodriguez";
            Console.WriteLine();

        }
    }
}
