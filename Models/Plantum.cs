using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Plantum
    {
        public Plantum()
        {
            MaquinaFisicas = new HashSet<MaquinaFisica>();
            Naves = new HashSet<Nave>();
        }

        public long IdPlanta { get; set; }
        public string IdPlantaExterno { get; set; }
        public string Acronimo { get; set; }
        public string Planta { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MaquinaFisica> MaquinaFisicas { get; set; }
        public virtual ICollection<Nave> Naves { get; set; }
    }
}
