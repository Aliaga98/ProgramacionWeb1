using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class Voluntariado
    {
        public Voluntariado()
        {
            DetalleVoluntarios = new HashSet<DetalleVoluntarios>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int Cupos { get; set; }
        public string Foto { get; set; }
        public int? IdOrganizacion { get; set; }

        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<DetalleVoluntarios> DetalleVoluntarios { get; set; }
    }
}
