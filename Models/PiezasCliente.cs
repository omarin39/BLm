using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class PiezasCliente
    {
        public long ClientesIdCliente { get; set; }
        public long PiezasIdPieza { get; set; }

        public virtual Pieza PiezasIdPiezaNavigation { get; set; }
    }
}
