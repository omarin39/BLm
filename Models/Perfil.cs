using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilOperacionPermisos = new HashSet<PerfilOperacionPermiso>();
        }

        public long Id { get; set; }
        public string Perfil1 { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
    }
}
