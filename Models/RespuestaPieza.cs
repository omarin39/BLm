using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class RespuestaPieza
    {
        public long IdResultadoPieza { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadoPiezaIdResultadoPieza { get; set; }
        public long PreguntaPiezaIdPreguntaPieza { get; set; }

        public virtual PreguntaPieza PreguntaPiezaIdPreguntaPiezaNavigation { get; set; }
        public virtual ResultadoPieza ResultadoPiezaIdResultadoPiezaNavigation { get; set; }
    }
}
