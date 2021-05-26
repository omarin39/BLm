using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class PreguntaProceso
    {
        public PreguntaProceso()
        {
            RespuestaProcesos = new HashSet<RespuestaProceso>();
        }

        public long IdPreguntaProceso { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long MaquinaProcesoIdMaquinaProceso { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelCertificacionIdNivelCertificacion { get; set; }
        public bool Activo { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual MaquinaProceso MaquinaProcesoIdMaquinaProcesoNavigation { get; set; }
        public virtual NivelCertificacion NivelCertificacionIdNivelCertificacionNavigation { get; set; }
        public virtual ICollection<RespuestaProceso> RespuestaProcesos { get; set; }
    }
}
