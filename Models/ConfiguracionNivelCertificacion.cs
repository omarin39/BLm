using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ConfiguracionNivelCertificacion
    {
        public long IdConfiguraNivelCertifica { get; set; }
        public long IdNivelCertificacion { get; set; }
        public int PlazoCertificaOperNuevo { get; set; }
        public int PlazoCertificaOperAntiguo { get; set; }
        public int ReintentosOperNuevo { get; set; }
        public int ReintentosOperAntiguo { get; set; }
        public int PlazoReCertificaOperNuevo { get; set; }
        public int PlazoReCertificaOperAntiguo { get; set; }
        public string IdsPerfilFirman { get; set; }
        public string IdsPerfilExaminan { get; set; }

        public virtual NivelCertificacion IdNivelCertificacionNavigation { get; set; }
    }
}
