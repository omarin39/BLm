using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwPiezaprocesoasignacapacitacion
    {
        public long IdPieza { get; set; }
        public long IdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Dificultad { get; set; }
    }
}
