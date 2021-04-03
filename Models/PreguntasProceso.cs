using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class PreguntasProceso
    {
        public PreguntasProceso()
        {
            RespuestasProcesos = new HashSet<RespuestasProceso>();
        }

        public long IdPreguntaProceso { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long ProcesosIdProceso { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelesCertificacionIdNivelCertificacion { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual NivelesCertificacion NivelesCertificacionIdNivelCertificacionNavigation { get; set; }
        public virtual Proceso ProcesosIdProcesoNavigation { get; set; }
        public virtual ICollection<RespuestasProceso> RespuestasProcesos { get; set; }
    }
}
