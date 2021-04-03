using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class DocumentosPiezaProceso
    {
        public long IdDocumentoPiezaProceso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
    }
}
