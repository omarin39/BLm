using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPerfiles
    {   
        public long Id { get; set; }     
        public string Perfil1{ get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }

    }
}
