using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestNivelesCertificacionAsignaCapacitacion
    {
        public long IdEmpleado { get; set; }
        public string Pieza { get; set; }
        public long IdProceso { get; set; }
        public string Maquina { get; set; }
        //public long IdNivelCertificacion { get; set; }
    }
}
