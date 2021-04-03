using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Cliente
    {
        public long IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
