using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            MultiMediaPiezas = new HashSet<MultiMediaPieza>();
        }

        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoDocumento1 { get; set; }

        public virtual ICollection<MultiMediaPieza> MultiMediaPiezas { get; set; }
    }
}
