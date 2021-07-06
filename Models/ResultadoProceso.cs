using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ResultadoProceso
    {
        public ResultadoProceso()
        {
            RespuestaProcesos = new HashSet<RespuestaProceso>();
        }

        public long IdResultadoProceso { get; set; }
        public long IdExamenCertificacion { get; set; }
        public double Resultado { get; set; }
        public string EstatusResultado { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<RespuestaProceso> RespuestaProcesos { get; set; }
    }
}
