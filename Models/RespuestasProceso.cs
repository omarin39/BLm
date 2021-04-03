using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class RespuestasProceso
    {
        public long IdRespuestaProceso { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadosProcesoIdResultadoProceso { get; set; }
        public long PreguntasProcesosIdPreguntaProceso { get; set; }

        public virtual PreguntasProceso PreguntasProcesosIdPreguntaProcesoNavigation { get; set; }
        public virtual ResultadosProceso ResultadosProcesoIdResultadoProcesoNavigation { get; set; }
    }
}
