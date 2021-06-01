using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Workflow
    {
        public long IdWorkFlow { get; set; }
        public long PiezaIdPieza { get; set; }
        public long ProcesoIdProceso { get; set; }
        public int? Tiempo { get; set; }
        public int Orden { get; set; }
        public bool Activo { get; set; }

        public virtual Pieza PiezaIdPiezaNavigation { get; set; }
        public virtual Proceso ProcesoIdProcesoNavigation { get; set; }
    }
}
