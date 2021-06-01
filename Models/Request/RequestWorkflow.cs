using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestWorkflow
    {
        public long IdWorkFlow { get; set; }
        public long PiezaIdPieza { get; set; }
        public long ProcesoIdProceso { get; set; }
        public int? Tiempo { get; set; }
        public int Orden { get; set; }
        public bool Activo { get; set; }
    }
}
