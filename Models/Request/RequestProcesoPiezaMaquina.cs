using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestProcesoPiezaMaquina
    {
        public long IdProcesoPiezaMaquina { get; set; }
        public long PiezaIdPieza { get; set; }
        public long MaquinaProcesoIdMaquinaProceso { get; set; }
        public bool UsaPreguntaEstandar { get; set; }
        public bool Activo { get; set; }
    }
}
