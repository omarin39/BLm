using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Nafe
    {
        public Nafe()
        {
            LineasProduccions = new HashSet<LineasProduccion>();
            MáquinasFisicas = new HashSet<MáquinasFisica>();
        }

        public long IdNave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long PlantasIdPlanta { get; set; }
        public bool? Activo { get; set; }

        public virtual Planta PlantasIdPlantaNavigation { get; set; }
        public virtual ICollection<LineasProduccion> LineasProduccions { get; set; }
        public virtual ICollection<MáquinasFisica> MáquinasFisicas { get; set; }
    }
}
