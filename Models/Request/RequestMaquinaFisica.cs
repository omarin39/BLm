using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestMaquinaFisica
    {
        public long IdMaquinaFisica { get; set; }
        public string Nserie { get; set; }
        public string Ubicacion { get; set; }
        public bool MaquinaPt { get; set; }
        public long MaquinaIdMaquina { get; set; }
        public long PlantaIdPlanta { get; set; }
        public long NaveIdNave { get; set; }
        public long LineaProduccionIdLineaProduccion { get; set; }
        public bool Activo { get; set; }
    }
}
