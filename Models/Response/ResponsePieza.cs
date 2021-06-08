using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponsePieza
    {
        public long IdPieza { get; set; }
        public string NumeroParte { get; set; }
        public string Nombre { get; set; }
       // public string Descripcion { get; set; }
       // public bool? Activo { get; set; }
    }
}
