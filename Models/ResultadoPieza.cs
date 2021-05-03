using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ResultadoPieza
    {
        public ResultadoPieza()
        {
            RespuestaPiezas = new HashSet<RespuestaPieza>();
        }

        public long IdResultadoPieza { get; set; }
        public double Resultado { get; set; }

        public virtual ICollection<RespuestaPieza> RespuestaPiezas { get; set; }
    }
}
