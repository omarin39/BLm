using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPlanta
    {
        public long IdPlanta { get; set; }
        public string IdPlantaExterno { get; set; }
        public string Acronimo { get; set; }
        public string Planta { get; set; }
        public bool? Activo { get; set; }

    }
}
