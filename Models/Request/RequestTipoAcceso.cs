using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestTipoAcceso
    {
        public long IdTipoAcceso { get; set; }
        public string DescTipoAcceso { get; set; }

    }
}
