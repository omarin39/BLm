using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Nave
    {
        public Nave()
        {
            LineaProduccions = new HashSet<LineaProduccion>();
            MaquinaFisicas = new HashSet<MaquinaFisica>();
        }

        public long IdNave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long PlantaIdPlanta { get; set; }
        public bool? Activo { get; set; }

        public virtual Plantum PlantaIdPlantaNavigation { get; set; }
        public virtual ICollection<LineaProduccion> LineaProduccions { get; set; }
        public virtual ICollection<MaquinaFisica> MaquinaFisicas { get; set; }
    }
}
