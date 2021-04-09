using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestIdiomas
    {
        public long IdIdioma { get; set; }
        public string CodigoIdioma { get; set; }
        public string Idioma1 { get; set; }
        public bool? Activo { get; set; }
    }
}
