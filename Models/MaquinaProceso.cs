using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class MaquinaProceso
    {
        public MaquinaProceso()
        {
            PreguntaProcesos = new HashSet<PreguntaProceso>();
            ProcesoPiezaMaquinas = new HashSet<ProcesoPiezaMaquina>();
        }

        public long IdMaquinaProceso { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long ProcesoIdProceso { get; set; }
        public bool UsaPreguntaEstandar { get; set; }
        public bool? Activo { get; set; }

        public virtual Proceso ProcesoIdProcesoNavigation { get; set; }
        public virtual ICollection<PreguntaProceso> PreguntaProcesos { get; set; }
        public virtual ICollection<ProcesoPiezaMaquina> ProcesoPiezaMaquinas { get; set; }
    }
}
