using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestLineaProduccion
    {
         public long Id { get; set; }
        public long IdNave { get; set; }
        public string NombreLinea { get; set; }
        public string DescripcionLinea { get; set; }
        public bool? Activo { get; set; }

    }
}
