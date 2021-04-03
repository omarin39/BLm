using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class MáquinasFisica
    {
        public long IdMaquinaFisica { get; set; }
        public string NSerie { get; set; }
        public string Ubicacion { get; set; }
        public long MaquinasIdMaquina { get; set; }
        public long NavesIdNave { get; set; }

        public virtual Maquina MaquinasIdMaquinaNavigation { get; set; }
        public virtual Nafe NavesIdNaveNavigation { get; set; }
    }
}
