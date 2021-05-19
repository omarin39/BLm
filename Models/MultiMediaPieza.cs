using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class MultiMediaPieza
    {
        public long Id { get; set; }
        public long IdPieza { get; set; }
        public long IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public bool? Recertificacion { get; set; }
        public string Ruta { get; set; }
        public string TipoMedia { get; set; }
        public string Extension { get; set; }
        public string Tamanio { get; set; }
        public bool Activo { get; set; }

        public virtual Pieza IdPiezaNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}
