using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ProcessLog
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public DateTime Fecha { get; set; }
        public string Data { get; set; }
        public string Respuesta { get; set; }
        public long Codigo { get; set; }
    }
}
