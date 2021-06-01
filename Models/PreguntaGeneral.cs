﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class PreguntaGeneral
    {
        public long IdPreguntaGeneral { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelCertificacionIdNivelCertificacion { get; set; }
        public long TipoPreguntaIdTipoPregunta { get; set; }
        public bool Activo { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual NivelCertificacion NivelCertificacionIdNivelCertificacionNavigation { get; set; }
        public virtual TipoPreguntum TipoPreguntaIdTipoPreguntaNavigation { get; set; }
    }
}
