using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Operacions = new HashSet<Operacion>();
        }

        public long Id { get; set; }
        public string NombreMenu { get; set; }
        public string Icon { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
