using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestConfiguracionNivelesCertificacion
    {
        public long IdConfiguraNivelCertifica { get; set; }
        public long IdNivelCertificacion { get; set; }
        public int PlazoCertificaOperNuevo { get; set; }
        public int PlazoCertificaOperAntiguo { get; set; }
        public int ReintentosOperNuevo { get; set; }
        public int ReintentosOperAntiguo { get; set; }
        public int PlazoReCertificaOperNuevo { get; set; }
        public int PlazoReCertificaOperAntiguo { get; set; }
        public List<Perfil> IdsPerfilFirman { get; set; }
        public List<Perfil> IdsPerfilExaminan { get; set; }
    }
}
