using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestMaquinaProceso
    {
        public long IdMaquinaProceso { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long ProcesoIdProceso { get; set; }
        public bool? Activo { get; set; }
        public bool UsaPreguntaEstandar { get; set; }

    }
}
