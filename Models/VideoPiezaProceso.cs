using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VideoPiezaProceso
    {
        public long IdVideoPiezaProceso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
    }
}
