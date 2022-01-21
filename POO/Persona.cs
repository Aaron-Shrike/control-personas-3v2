using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    class Persona
    {

        private string nombres;

        public string Nombres
        {
            get
            {
                return this.nombres;
            }
            set
            {
                if (value.Length > 1)
                {
                    this.nombres = value;
                }
                else
                {
                    throw new ArgumentException("Argumento no válido");
                }
            }
        }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string DNI { get; set; }
        public int Edad { get; set; }

        public string NombreCompleto
        {
            set
            {
                string [] nombres = value.Split();

                if (nombres.Length >= 3 && nombres.Length <= 4)
                {
                    this.nombres = nombres[0];
                    if (nombres.Length == 4)
                    {
                        this.nombres += " " + nombres[1];
                    }
                    this.ApellidoPaterno = nombres[nombres.Length - 2];
                    this.ApellidoMaterno = nombres[nombres.Length -1];
                }
                else
                {
                    throw new ArgumentException("El valor indicado no es válido");
                }
            }
            get
            {
                return this.ApellidoPaterno + " " + this.ApellidoMaterno + " " + this.Nombres;
            }
        }

        public string Correo { get; set; }

        public Persona()
        {
            //Singleton
        }

        public Persona(string nombres, string apellidoPaterno, string apellidoMaterno)
        {
            this.Nombres = nombres;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
        }


        public bool MayorEdad
        {
            get
            {
                return this.Edad >= 18 ? true : false;
            }
        }
    }
}
