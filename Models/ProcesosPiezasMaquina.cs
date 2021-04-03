using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class ProcesosPiezasMaquina
    {
        public long PiezasIdPieza { get; set; }

        public virtual Pieza PiezasIdPiezaNavigation { get; set; }
    }
}
