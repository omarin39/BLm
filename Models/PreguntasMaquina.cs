using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class PreguntasMaquina
    {
        public PreguntasMaquina()
        {
            RespuestasMaquinas = new HashSet<RespuestasMaquina>();
        }

        public long IdPreguntaMaquina { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long MaquinasIdMaquina { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelesCertificacionIdNivelCertificacion { get; set; }

        public virtual Idioma IdiomaIdIdiomaNavigation { get; set; }
        public virtual Maquina MaquinasIdMaquinaNavigation { get; set; }
        public virtual NivelesCertificacion NivelesCertificacionIdNivelCertificacionNavigation { get; set; }
        public virtual ICollection<RespuestasMaquina> RespuestasMaquinas { get; set; }
    }
}
