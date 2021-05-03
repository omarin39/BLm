using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPreguntaPtGeneral
    {   
        public long idPregunta { get; set; }     
        public string pregunta { get; set; }
        public string respuesta { get; set; }
        public int orden { get; set; }
        public int idiomaIdIdioma { get; set; }
        public int idNiveCertificacion { get; set; }

    }
}
