using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestOperacion
    {
        public long Id { get; set; }
        public String Operacion { get; set; }
        public String Nombre_Menu { get; set; }
        public String Nombre_Pagina { get; set; }
        public bool Activo { get; set; }

    }
}
