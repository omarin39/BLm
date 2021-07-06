using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ExamenDeCertificacion
    {
        public ExamenDeCertificacion()
        {
            Certificacions = new HashSet<Certificacion>();
            ResultadoGeneralExamenCertificacionMaquinaProcesoPiezas = new HashSet<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza>();
        }

        public long IdExamenCertificacion { get; set; }
        public long IdCapacitacionEmpleado { get; set; }
        public double TotalFinalExamen { get; set; }
        public DateTime FechaExamen { get; set; }
        public DateTime? FechaFirmaFinal { get; set; }
        public bool EstadoExamen { get; set; }
        public bool Concluido { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Certificacion> Certificacions { get; set; }
        public virtual ICollection<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza> ResultadoGeneralExamenCertificacionMaquinaProcesoPiezas { get; set; }
    }
}
