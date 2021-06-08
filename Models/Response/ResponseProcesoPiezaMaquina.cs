using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseProcesoPiezaMaquina
    {
        public long IdProcesoPiezaMaquina { get; set; }
        public long PiezaIdPieza { get; set; }
        public long MaquinaProcesoIdMaquinaProceso { get; set; }
        public bool UsaPreguntaEstandar { get; set; }
        public bool Activo { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
        public long ProcesoIdProceso { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public int? CountPreguntas { get; set; }
        public int? CountDoc { get; set; }
        public int? CountVideo { get; set; }
    }
}
