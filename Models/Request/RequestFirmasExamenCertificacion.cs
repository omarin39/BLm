using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestFirmasExamenCertificacion
    {
        public long IdExamenCertificacion { get; set; }
        public long IdTipoFirma { get; set; }
    }
}
