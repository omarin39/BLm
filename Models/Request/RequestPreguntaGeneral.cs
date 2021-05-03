using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPreguntaGeneral
    {
        public long idPregunta { get; set; }
        public string pregunta { get; set; }
        public string respuesta { get; set; }
        public int orden { get; set; }
        public long idIdioma { get; set; }
        public long idNivelCertificcion { get; set; }
    }
}
