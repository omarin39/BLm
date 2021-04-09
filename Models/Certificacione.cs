using System;
using System.Collections.Generic;

#nullable disable

namespace APIRest.Models
{
    public partial class Certificacione
    {
        public long IdCertificacion { get; set; }
        public DateTime FechaEntrenamiento { get; set; }
        public DateTime? FechaCertificacion { get; set; }
        public long? IdCertificador { get; set; }
        public string TokenCertificador { get; set; }
        public DateTime? FechaCertificador { get; set; }
        public long? IdMentor { get; set; }
        public string TokenMentor { get; set; }
        public DateTime? FechaMentor { get; set; }
        public long? IdResponsable { get; set; }
        public string TokenResponsable { get; set; }
        public DateTime? FechaResponsable { get; set; }
        public double? Resultado { get; set; }
        public bool? Activo { get; set; }
    }
}
