using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ResultadoGeneralExamenCertificacionMaquinaProcesoPieza
    {
        public long IdResultadoGeneral { get; set; }
        public long IdExamenCertificacion { get; set; }
        public long IdGlobal { get; set; }
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public bool Demuestra { get; set; }
        public bool Reforzar { get; set; }
        public bool NoDemuestra { get; set; }
        public double Resultado { get; set; }
        public bool IsGral { get; set; }
        public long IdIdioma { get; set; }
        public long TipoPregunta { get; set; }
        public long IdNivelCertificacion { get; set; }
        public bool Activo { get; set; }

        public virtual ExamenDeCertificacion IdExamenCertificacionNavigation { get; set; }
        public virtual TipoPreguntum TipoPreguntaNavigation { get; set; }
    }
}
