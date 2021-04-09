using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Pieza
    {
        public Pieza()
        {
            PreguntasPiezas = new HashSet<PreguntasPieza>();
        }

        public long IdPieza { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<PreguntasPieza> PreguntasPiezas { get; set; }
    }
}
