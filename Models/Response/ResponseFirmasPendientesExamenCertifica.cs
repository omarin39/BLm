using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseFirmasPendientesExamenCertifica
    {
        public long IdExamenCertificacion { get; set; }
        public long IdCapacitacionEmpleado { get; set; }
        public double TotalFinalExamen { get; set; }
        public bool EstadoExamen { get; set; }
        public bool Concluido { get; set; }
        public long NominaEmpleado { get; set; }
        public long IdEmpleado { get; set; }
        public string Pieza { get; set; }
        public long IdProceso { get; set; }
        public string Maquina { get; set; }
        public long IdNivelCertificacion { get; set; }
        public string NombreEmpleado { get; set; }
        public string NombreProceso { get; set; }
        public string NombreNivel { get; set; }
        public string NombreMaquina { get; set; }
        public string NombrePieza { get; set; }
        public bool Activo { get; set; }
    }
}
