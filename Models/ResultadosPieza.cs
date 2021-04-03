using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class ResultadosPieza
    {
        public ResultadosPieza()
        {
            RespuestasPiezas = new HashSet<RespuestasPieza>();
        }

        public long IdResultadoPieza { get; set; }
        public double Resultado { get; set; }

        public virtual ICollection<RespuestasPieza> RespuestasPiezas { get; set; }
    }
}
