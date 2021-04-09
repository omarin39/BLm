using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public long IdPuesto { get; set; }
        public long IdPuestoExt { get; set; }
        public string DescPuesto { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
