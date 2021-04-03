using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class UnidadNegocio
    {
        public UnidadNegocio()
        {
            Empleados = new HashSet<Empleado>();
        }

        public long IdUnidadNegocio { get; set; }
        public long IdUnidadNegocioExt { get; set; }
        public string DescUnidadNegocio { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
