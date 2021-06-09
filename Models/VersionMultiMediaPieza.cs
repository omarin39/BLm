using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VersionMultiMediaPieza
    {
        public long IdVersion { get; set; }
        public long IdMultiMediaPieza { get; set; }
        public long IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public bool? Recertificacion { get; set; }
        public string Ruta { get; set; }
        public string TipoMedia { get; set; }
        public string Extension { get; set; }
        public string Tamanio { get; set; }

        public virtual MultiMediaPieza IdMultiMediaPiezaNavigation { get; set; }
    }
}
