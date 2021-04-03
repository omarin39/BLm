using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class TipoAcceso
    {
        public TipoAcceso()
        {
            Maquinas = new HashSet<Maquina>();
        }

        public long IdTipoAcceso { get; set; }
        public string DescTipoAcceso { get; set; }

        public virtual ICollection<Maquina> Maquinas { get; set; }
    }
}
