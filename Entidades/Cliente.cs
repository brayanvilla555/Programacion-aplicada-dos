using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion_aplicada_dos.Entidades
{
    internal class Cliente
    {
        public int idCliente { get; set; }
        public string nombres {  get; set; }
        public string apellidos { get; set; }
        public string dni {  get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Cliente()
        {
        }
        public Cliente(int idCliente, string nombres, string apellidos, string dni, DateTime fechaNacimiento)
        {
            this.idCliente = idCliente;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
        }

        public Cliente(string nombres, string apellidos, string dni, DateTime fechaNacimiento)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
        }
    }
}
