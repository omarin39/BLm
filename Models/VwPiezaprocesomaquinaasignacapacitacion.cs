using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwPiezaprocesomaquinaasignacapacitacion
    {
        public long IdMaquinaProceso { get; set; }
        public long IdProceso { get; set; }
        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
    }
}
