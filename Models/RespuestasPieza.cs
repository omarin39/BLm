using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class RespuestasPieza
    {
        public long IdResultadoPieza { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadosPiezaIdResultadoPieza { get; set; }
        public long PreguntasPiezasIdPreguntaPieza { get; set; }

        public virtual PreguntasPieza PreguntasPiezasIdPreguntaPiezaNavigation { get; set; }
        public virtual ResultadosPieza ResultadosPiezaIdResultadoPiezaNavigation { get; set; }
    }
}
