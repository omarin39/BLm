using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwPiezasMultimedia
    {
        public long IdPieza { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int? CountDoc { get; set; }
        public int? CountVideo { get; set; }
        public int? CountImg { get; set; }
    }
}
