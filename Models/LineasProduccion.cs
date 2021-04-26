using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class LineasProduccion
    {
        public long Id { get; set; }
        public long IdNave { get; set; }
        public string NombreLinea { get; set; }
        public string DescripcionLinea { get; set; }
        public bool? Activo { get; set; }

        public virtual Nafe IdNaveNavigation { get; set; }
    }
}
