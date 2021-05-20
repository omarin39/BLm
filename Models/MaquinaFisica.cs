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
        public long MaquinaIdMaquina { get; set; }
        public long NaveIdNave { get; set; }
        public bool Activo { get; set; }

        public virtual Nave NaveIdNaveNavigation { get; set; }
    }
}
