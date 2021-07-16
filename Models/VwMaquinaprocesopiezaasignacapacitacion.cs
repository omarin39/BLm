using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwMaquinaprocesopiezaasignacapacitacion
    {
        public long IdMaquinaProceso { get; set; }
        public long ProcesoIdProceso { get; set; }
        public long IdPieza { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
    }
}
