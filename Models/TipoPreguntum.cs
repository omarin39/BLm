using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class TipoPreguntum
    {
        public TipoPreguntum()
        {
            PreguntaGenerals = new HashSet<PreguntaGeneral>();
        }

        public long IdTipoPregunta { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PreguntaGeneral> PreguntaGenerals { get; set; }
    }
}
