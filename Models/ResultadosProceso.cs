using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class ResultadosProceso
    {
        public ResultadosProceso()
        {
            RespuestasProcesos = new HashSet<RespuestasProceso>();
        }

        public long IdResultadoProceso { get; set; }
        public double Resultado { get; set; }

        public virtual ICollection<RespuestasProceso> RespuestasProcesos { get; set; }
    }
}
