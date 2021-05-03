using APIRestV2.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseProcessLogDate
    {
        public long Id { get; set; }
        public string IP { get; set; }
        public string Fecha { get; set; }
        public string Data { get; set; }
        public string Respuesta { get; set; }
        public long Codigo { get; set; }

    }


}
