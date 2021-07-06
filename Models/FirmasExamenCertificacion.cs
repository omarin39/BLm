using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class FirmasExamenCertificacion
    {
        public long IdFirmaExamen { get; set; }
        public long IdExamenCertificacion { get; set; }
        public long IdTipoFirma { get; set; }
        public DateTime FechaFirma { get; set; }
        public bool Activo { get; set; }

        public virtual TipoFirmaExamenCertifica IdTipoFirmaNavigation { get; set; }
    }
}
