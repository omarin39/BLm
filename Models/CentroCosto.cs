using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class CentroCosto
    {
        public CentroCosto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public long IdCentroCosto { get; set; }
        public long IdCentroCostoExterno { get; set; }
        public string DescCentroCosto { get; set; }
        public long DuenoCeco { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
