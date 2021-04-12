using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestPlanta
    {   
        public long IdPlanta { get; set; }     
        public string acronimo { get; set; }
        public string planta { get; set; }
        public bool Activo { get; set; }
        
    }
}
