using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseCertificacionEmpleado
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
        public long IdExamenDeCertificacion { get; set; }
        public long IdNivelCertificacion { get; set; }
        public bool? Activo { get; set; }
        public long IdCapacitacion { get; set; }
        public long IdEmpleado { get; set; }
        public string Pieza { get; set; }
        public long IdProceso { get; set; }
        public string Maquina { get; set; }
        public string NombreProceso { get; set; }
        public string NombreNivel { get; set; }
    }
}
