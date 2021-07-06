using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ResultadoMaquina
    {
        public ResultadoMaquina()
        {
            RespuestaMaquinas = new HashSet<RespuestaMaquina>();
        }

        public long IdResultadoMaquina { get; set; }
        public long IdExamenCertificacion { get; set; }
        public double Resultado { get; set; }
        public string EstatusResultado { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<RespuestaMaquina> RespuestaMaquinas { get; set; }
    }
}
