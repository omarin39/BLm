using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            PreguntasProcesos = new HashSet<PreguntasProceso>();
        }

        public long IdProceso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<PreguntasProceso> PreguntasProcesos { get; set; }
    }
}
