using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Pieza
    {
        public Pieza()
        {
            MultiMediaPiezas = new HashSet<MultiMediaPieza>();
            PiezaClientes = new HashSet<PiezaCliente>();
            PreguntaPiezas = new HashSet<PreguntaPieza>();
        }

        public long IdPieza { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MultiMediaPieza> MultiMediaPiezas { get; set; }
        public virtual ICollection<PiezaCliente> PiezaClientes { get; set; }
        public virtual ICollection<PreguntaPieza> PreguntaPiezas { get; set; }
    }
}
