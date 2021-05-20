﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            MaquinaProcesos = new HashSet<MaquinaProceso>();
            PreguntaProcesos = new HashSet<PreguntaProceso>();
        }

        public long IdProceso { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MaquinaProceso> MaquinaProcesos { get; set; }
        public virtual ICollection<PreguntaProceso> PreguntaProcesos { get; set; }
    }
}
