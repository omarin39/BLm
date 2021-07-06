using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwMaquinaprocesoasignacapacitacion
    {
        public long IdMaquinaProceso { get; set; }
        public long IdMaquina { get; set; }
        public long IdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Dificultad { get; set; }
    }
}
