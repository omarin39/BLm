using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class MaquinasProceso
    {
        public long MaquinasIdMaquina { get; set; }
        public long ProcesosIdProceso { get; set; }
        public bool? Activo { get; set; }

        public virtual Proceso ProcesosIdProcesoNavigation { get; set; }
    }
}
