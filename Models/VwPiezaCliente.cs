using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwPiezaCliente
    {
        public long ClienteIdCliente { get; set; }
        public long PiezaIdPieza { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
