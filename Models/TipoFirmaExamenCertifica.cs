using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class TipoFirmaExamenCertifica
    {
        public TipoFirmaExamenCertifica()
        {
            FirmasExamenCertificacions = new HashSet<FirmasExamenCertificacion>();
        }

        public long IdTipoFirma { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<FirmasExamenCertificacion> FirmasExamenCertificacions { get; set; }
    }
}
