using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class CentroCosto
    {
        public long IdCentroCosto { get; set; }
        public long IdCentroCostoExterno { get; set; }
        public string DescCentroCosto { get; set; }
        public long DuenoCeco { get; set; }
        public bool? Activo { get; set; }
    }
}
