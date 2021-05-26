using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ProcesoPiezaMaquina
    {
        public ProcesoPiezaMaquina()
        {
            PreguntaPiezas = new HashSet<PreguntaPieza>();
        }

        public long IdProcesoPiezaMaquina { get; set; }
        public long PiezaIdPieza { get; set; }
        public long MaquinaProcesoIdMaquinaProceso { get; set; }
        public bool UsaPreguntaEstandar { get; set; }
        public bool Activo { get; set; }

        public virtual MaquinaProceso MaquinaProcesoIdMaquinaProcesoNavigation { get; set; }
        public virtual Pieza PiezaIdPiezaNavigation { get; set; }
        public virtual ICollection<PreguntaPieza> PreguntaPiezas { get; set; }
    }
}
