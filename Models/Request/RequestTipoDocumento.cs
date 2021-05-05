using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestTipoDocumento
    {
    
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoDocumento1 { get; set; }

    }


}
