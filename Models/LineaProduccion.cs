using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class LineaProduccion
    {
        public long Id { get; set; }
        public long IdNave { get; set; }
        public string NombreLinea { get; set; }
        public string DescripcionLinea { get; set; }
        public bool? Activo { get; set; }

        public virtual Nave IdNaveNavigation { get; set; }
    }
}
