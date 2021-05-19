using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Puesto
    {
        public long IdPuesto { get; set; }
        public long IdPuestoExterno { get; set; }
        public string DescPuesto { get; set; }
        public bool? Activo { get; set; }
    }
}
