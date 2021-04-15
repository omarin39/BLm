using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Planta
    {
        public Planta()
        {
            Naves = new HashSet<Nafe>();
        }

        public long IdPlanta { get; set; }
        public long? IdPlantaExt { get; set; }
        public string Acronimo { get; set; }
        public string Planta1 { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Nafe> Naves { get; set; }
    }
}
