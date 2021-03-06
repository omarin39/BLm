using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class MaquinaFisica
    {
        public long IdMaquinaFisica { get; set; }
        public string Nserie { get; set; }
        public string Ubicacion { get; set; }
        public bool MaquinaPt { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long PlantaIdPlanta { get; set; }
        public long NaveIdNave { get; set; }
        public long LineaProduccionIdLineaProduccion { get; set; }
        public bool Activo { get; set; }

        public virtual LineaProduccion LineaProduccionIdLineaProduccionNavigation { get; set; }
        public virtual Maquina MaquinaIdMaquinaNavigation { get; set; }
        public virtual Nave NaveIdNaveNavigation { get; set; }
        public virtual Plantum PlantaIdPlantaNavigation { get; set; }
    }
}
