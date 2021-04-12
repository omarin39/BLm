using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestNave
    {   
        public long IdNave { get; set; }     
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool Activo { get; set; }
        
    }
}
