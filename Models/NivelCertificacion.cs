using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class NivelCertificacion
    {
        public NivelCertificacion()
        {
            Certificacions = new HashSet<Certificacion>();
            ConfiguracionNivelCertificacions = new HashSet<ConfiguracionNivelCertificacion>();
            PreguntaGenerals = new HashSet<PreguntaGeneral>();
            PreguntaMaquinaGenerals = new HashSet<PreguntaMaquinaGeneral>();
            PreguntaPiezaGenerals = new HashSet<PreguntaPiezaGeneral>();
            PreguntaPiezas = new HashSet<PreguntaPieza>();
            PreguntaProcesoGenerals = new HashSet<PreguntaProcesoGeneral>();
            PreguntaProcesos = new HashSet<PreguntaProceso>();
            PreguntaPtGenerals = new HashSet<PreguntaPtGeneral>();
        }

        public long IdNivelCertificacion { get; set; }
        public string NombreNivelCertificacion { get; set; }
        public string DescripcionNivelCertificacion { get; set; }
        public int DificultadNivelCertificacion { get; set; }
        public string Color { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Certificacion> Certificacions { get; set; }
        public virtual ICollection<ConfiguracionNivelCertificacion> ConfiguracionNivelCertificacions { get; set; }
        public virtual ICollection<PreguntaGeneral> PreguntaGenerals { get; set; }
        public virtual ICollection<PreguntaMaquinaGeneral> PreguntaMaquinaGenerals { get; set; }
        public virtual ICollection<PreguntaPiezaGeneral> PreguntaPiezaGenerals { get; set; }
        public virtual ICollection<PreguntaPieza> PreguntaPiezas { get; set; }
        public virtual ICollection<PreguntaProcesoGeneral> PreguntaProcesoGenerals { get; set; }
        public virtual ICollection<PreguntaProceso> PreguntaProcesos { get; set; }
        public virtual ICollection<PreguntaPtGeneral> PreguntaPtGenerals { get; set; }
    }
}
