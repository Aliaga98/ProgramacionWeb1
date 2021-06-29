using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class Recolecion
    {
        public Recolecion()
        {
            DetalleDonacion = new HashSet<DetalleDonacion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Lugar { get; set; }
        public string Necesidaes { get; set; }
        public string Beneficiarios { get; set; }
        public int? IdOrga { get; set; }

        public virtual Organizacion IdOrgaNavigation { get; set; }
        public virtual ICollection<DetalleDonacion> DetalleDonacion { get; set; }
    }
}
