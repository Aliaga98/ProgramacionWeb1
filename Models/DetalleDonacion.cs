using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class DetalleDonacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdDonador { get; set; }
        public int? IdRecoleccion { get; set; }

        public virtual Donadores IdDonadorNavigation { get; set; }
        public virtual Recolecion IdRecoleccionNavigation { get; set; }
    }
}
