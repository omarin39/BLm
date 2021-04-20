using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestNivelesCertificacion
    {
        public long Id { get; set; }
        public String nombreNivelCertificacion { get; set; }
        public String desc_nivel_certificacion { get; set; }
        public int dificultadNivelCertificacion { get; set; }
        public String color { get; set; }
        public bool activo { get; set; }


    }
}
