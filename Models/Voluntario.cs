using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class Voluntario
    {
        public Voluntario()
        {
            DetalleVoluntarios = new HashSet<DetalleVoluntarios>();
        }

        public int Id { get; set; }
        public int Ci { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public int Telefono { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public int TelefonoEmergencia { get; set; }

        public virtual ICollection<DetalleVoluntarios> DetalleVoluntarios { get; set; }
    }
}
