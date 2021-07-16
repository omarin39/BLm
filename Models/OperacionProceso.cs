using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class OperacionProceso
    {
        public long IdOperacionProceso { get; set; }
        public long IdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual Proceso IdProcesoNavigation { get; set; }
    }
}
