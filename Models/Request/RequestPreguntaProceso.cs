using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPreguntaProceso
    {
        public long IdPreguntaProceso { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long MaquinaProcesoIdMaquinaProceso { get; set; }
        public long IdiomaIdIdioma { get; set; }
        public long NivelCertificacionIdNivelCertificacion { get; set; }
        public bool Activo { get; set; }
    }
}
