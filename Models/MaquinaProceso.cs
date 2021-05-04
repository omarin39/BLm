﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class MaquinaProceso
    {
        public long MaquinaIdMaquina { get; set; }
        public long ProcesoIdProceso { get; set; }
        public bool? Activo { get; set; }

        public virtual Proceso ProcesoIdProcesoNavigation { get; set; }
    }
}