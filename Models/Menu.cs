using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public long Id { get; set; }
        public string NombreMenu { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
