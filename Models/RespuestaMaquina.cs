using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class RespuestaMaquina
    {
        public long IdRespuestaMaquina { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadoMaquinaIdResultadoMaquina { get; set; }
        public long PreguntaMaquinaIdPreguntaMaquina { get; set; }

        public virtual PreguntaMaquina PreguntaMaquinaIdPreguntaMaquinaNavigation { get; set; }
        public virtual ResultadoMaquina ResultadoMaquinaIdResultadoMaquinaNavigation { get; set; }
    }
}
