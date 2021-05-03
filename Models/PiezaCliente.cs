using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class PiezaCliente
    {
        public long ClienteIdCliente { get; set; }
        public long PiezaIdPieza { get; set; }
        public bool? Activo { get; set; }

        public virtual Pieza PiezaIdPiezaNavigation { get; set; }
    }
}
