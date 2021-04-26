using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Response
{
    public class ResponseNave
    {
        public long IdNave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long PlantasIdPlanta { get; set; }
        public bool? Activo { get; set; }

        public virtual Planta PlantasIdPlantaNavigation { get; set; }
        public int LineasProduccions { get; set; }
        public virtual ICollection<MáquinasFisica> MáquinasFisicas { get; set; }
    }
}
