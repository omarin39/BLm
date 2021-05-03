using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestNivelesCertificacion
    {
        public long IdNivelCertificacion { get; set; }
        public string NombreNivelCertificacion { get; set; }
        public string DescNivelCertificacion { get; set; }
        public int DificultadNivelCertificacion { get; set; }
        public string Color { get; set; }
        public bool Activo { get; set; }


    }
}
