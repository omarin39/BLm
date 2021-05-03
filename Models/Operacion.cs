using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Operacion
    {
        public Operacion()
        {
            PerfilOperacionPermisos = new HashSet<PerfilOperacionPermiso>();
        }

        public long Id { get; set; }
        public string Operacion1 { get; set; }
        public string NombreMenu { get; set; }
        public string NombrePagina { get; set; }
        public long IdMenu { get; set; }
        public bool Activo { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual ICollection<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
    }
}
