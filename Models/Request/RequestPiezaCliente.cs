using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPiezaCliente
    {
        public long ClienteIdCliente { get; set; }
        public long PiezaIdPieza { get; set; }
        public bool? Activo { get; set; }

    }
}
