using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Maquina
    {
        public Maquina()
        {
            MaquinaFisicas = new HashSet<MaquinaFisica>();
            MaquinaProcesos = new HashSet<MaquinaProceso>();
            PreguntaMaquinas = new HashSet<PreguntaMaquina>();
        }

        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public bool MaquinaPt { get; set; }
        public int CantidadAccesoMultiple { get; set; }
        public long FabricanteIdFabricante { get; set; }
        public long TipoAccesoIdTipoAcceso { get; set; }
        public bool? Activo { get; set; }

        public virtual Fabricante FabricanteIdFabricanteNavigation { get; set; }
        public virtual ICollection<MaquinaFisica> MaquinaFisicas { get; set; }
        public virtual ICollection<MaquinaProceso> MaquinaProcesos { get; set; }
        public virtual ICollection<PreguntaMaquina> PreguntaMaquinas { get; set; }
    }
}
