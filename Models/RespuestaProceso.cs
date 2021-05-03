using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class RespuestaProceso
    {
        public long IdRespuestaProceso { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadoProcesoIdResultadoProceso { get; set; }
        public long PreguntaProcesoIdPreguntaProceso { get; set; }

        public virtual PreguntaProceso PreguntaProcesoIdPreguntaProcesoNavigation { get; set; }
        public virtual ResultadoProceso ResultadoProcesoIdResultadoProcesoNavigation { get; set; }
    }
}
