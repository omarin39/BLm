using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Operacione
    {
        public Operacione()
        {
            PerfilOperacionPermisos = new HashSet<PerfilOperacionPermiso>();
        }

        public long Id { get; set; }
        public string Operacion { get; set; }
        public bool Estatus { get; set; }

        public virtual ICollection<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
    }
}
