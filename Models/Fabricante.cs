using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Maquinas = new HashSet<Maquina>();
        }

        public long IdFabricante { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Maquina> Maquinas { get; set; }
    }
}
