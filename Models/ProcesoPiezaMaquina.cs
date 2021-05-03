using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ProcesoPiezaMaquina
    {
        public long PiezaIdPieza { get; set; }

        public virtual Pieza PiezaIdPiezaNavigation { get; set; }
    }
}
