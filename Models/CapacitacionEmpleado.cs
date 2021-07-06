using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class CapacitacionEmpleado
    {
        public long IdCapacitacion { get; set; }
        public long IdEmpleado { get; set; }
        public string Pieza { get; set; }
        public long IdProceso { get; set; }
        public string Maquina { get; set; }
        public long IdNivelCertificacion { get; set; }
        public long? IdMentor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Turno { get; set; }
        public bool Concluida { get; set; }
        public bool Activo { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Proceso IdProcesoNavigation { get; set; }
    }
}
