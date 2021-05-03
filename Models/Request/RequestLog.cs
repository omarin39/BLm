using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestLog
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public DateTime Fecha { get; set; }
        public string Data { get; set; }
        public string Respuesta { get; set; }
        public long Codigo { get; set; }
    }
}
