using System;
using System.Collections.Generic;

namespace Login_Proyecto.Models
{
    public partial class DetalleVoluntarios
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdActi { get; set; }
        public int? IdVolun { get; set; }

        public virtual Voluntariado IdActiNavigation { get; set; }
        public virtual Voluntario IdVolunNavigation { get; set; }
    }
}
