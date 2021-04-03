using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class ResultadosMaquina
    {
        public ResultadosMaquina()
        {
            RespuestasMaquinas = new HashSet<RespuestasMaquina>();
        }

        public long IdResultadoMáquina { get; set; }
        public double Resultado { get; set; }

        public virtual ICollection<RespuestasMaquina> RespuestasMaquinas { get; set; }
    }
}
