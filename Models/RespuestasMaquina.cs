using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class RespuestasMaquina
    {
        public long IdRespuestaMaquina { get; set; }
        public string Respuesta { get; set; }
        public double Resultado { get; set; }
        public long ResultadosMaquinaIdResultadoMáquina { get; set; }
        public long PreguntasMaquinaIdPreguntaMaquina { get; set; }

        public virtual PreguntasMaquina PreguntasMaquinaIdPreguntaMaquinaNavigation { get; set; }
        public virtual ResultadosMaquina ResultadosMaquinaIdResultadoMáquinaNavigation { get; set; }
    }
}
