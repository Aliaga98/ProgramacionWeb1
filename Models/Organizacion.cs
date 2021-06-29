using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Recolecion = new HashSet<Recolecion>();
            Voluntariado = new HashSet<Voluntariado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public int Telefono { get; set; }
        public string Descripcion { get; set; }
        public int Socios { get; set; }
        public string Departamento { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Recolecion> Recolecion { get; set; }
        public virtual ICollection<Voluntariado> Voluntariado { get; set; }
    }
}
