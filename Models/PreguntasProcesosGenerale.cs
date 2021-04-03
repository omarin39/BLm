using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class PreguntasProcesosGenerale
    {
        public long IdPreguntaProceso { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public long Orden { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelesCertificacionIdNivelCertificacion { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual NivelesCertificacion NivelesCertificacionIdNivelCertificacionNavigation { get; set; }
    }
}
