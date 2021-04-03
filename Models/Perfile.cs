using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Perfile
    {
        public Perfile()
        {
            Empleados = new HashSet<Empleado>();
            PerfilOperacionPermisos = new HashSet<PerfilOperacionPermiso>();
        }

        public long Id { get; set; }
        public string Perfil { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
    }
}
