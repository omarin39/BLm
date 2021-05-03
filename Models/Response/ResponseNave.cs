using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseNave
    {
        public long IdNave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long PlantasIdPlanta { get; set; }
        public bool? Activo { get; set; }

        public virtual Plantum PlantasIdPlantaNavigation { get; set; }
        public int LineasProduccions { get; set; }
        public virtual ICollection<MaquinaFisica> MáquinasFisicas { get; set; }
    }
}
