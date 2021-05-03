using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class DocumentoPiezaProceso
    {
        public long IdDocumentoPiezaProceso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public bool? Activo { get; set; }
    }
}
