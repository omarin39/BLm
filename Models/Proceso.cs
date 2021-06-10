using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            CapacitacionEmpleados = new HashSet<CapacitacionEmpleado>();
            MaquinaProcesos = new HashSet<MaquinaProceso>();
            Workflows = new HashSet<Workflow>();
        }

        public long IdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Dificultad { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<CapacitacionEmpleado> CapacitacionEmpleados { get; set; }
        public virtual ICollection<MaquinaProceso> MaquinaProcesos { get; set; }
        public virtual ICollection<Workflow> Workflows { get; set; }
    }
}
