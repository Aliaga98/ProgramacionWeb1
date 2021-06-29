using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class Donadores
    {
        public Donadores()
        {
            DetalleDonacion = new HashSet<DetalleDonacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Telefono { get; set; }
        public string Ciudad { get; set; }

        public virtual ICollection<DetalleDonacion> DetalleDonacion { get; set; }
    }
}
