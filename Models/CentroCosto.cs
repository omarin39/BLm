using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class CentroCosto
    {
        public CentroCosto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public long IdCentroCosto { get; set; }
        public long IdCentroCostoExt { get; set; }
        public string DescCentroCosto { get; set; }
        public long DuenoCeco { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
