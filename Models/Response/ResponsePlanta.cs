using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponsePlanta
    {
        public long IdPlanta { get; set; }
        public long? IdPlantaExt { get; set; }
        public string Acronimo { get; set; }
        public string Planta1 { get; set; }
        public bool? Activo { get; set; }

        public int Naves { get; set; }
    }
}
