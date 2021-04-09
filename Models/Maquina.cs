using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Maquina
    {
        public Maquina()
        {
            MáquinasFisicas = new HashSet<MáquinasFisica>();
            PreguntasMaquinas = new HashSet<PreguntasMaquina>();
        }

        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public bool MaquinaPt { get; set; }
        public int CantidadAccesoMultiple { get; set; }
        public long FabricanteIdFabricante { get; set; }
        public long? TipoAccesoIdTipoAcceso { get; set; }
        public bool? Activo { get; set; }

        public virtual Fabricante FabricanteIdFabricanteNavigation { get; set; }
        public virtual TipoAcceso TipoAccesoIdTipoAccesoNavigation { get; set; }
        public virtual ICollection<MáquinasFisica> MáquinasFisicas { get; set; }
        public virtual ICollection<PreguntasMaquina> PreguntasMaquinas { get; set; }
    }
}
