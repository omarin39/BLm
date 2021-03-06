using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class PreguntaProcesoGeneral
    {
        public long IdPreguntaProceso { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public long Orden { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelCertificacionIdNivelCertificacion { get; set; }
        public bool Activo { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual NivelCertificacion NivelCertificacionIdNivelCertificacionNavigation { get; set; }
    }
}
