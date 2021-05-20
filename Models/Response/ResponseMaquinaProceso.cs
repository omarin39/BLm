using APIRestV2.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseMaquinaProceso
    {
        public long IdMaquinaProceso { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long ProcesoIdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public bool? Activo { get; set; }
        //public virtual RequestProceso Proceso { get; set; }
    }
}
