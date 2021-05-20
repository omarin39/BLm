using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class PreguntaMaquina
    {
        public PreguntaMaquina()
        {
            RespuestaMaquinas = new HashSet<RespuestaMaquina>();
        }

        public long IdPreguntaMaquina { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelCertificacionIdNivelCertificacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<RespuestaMaquina> RespuestaMaquinas { get; set; }
    }
}
