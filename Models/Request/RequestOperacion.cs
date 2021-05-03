using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestOperacion
    {
        public long Id { get; set; }
        public String Operacion { get; set; }
        public String Nombre_Menu { get; set; }
        public String Nombre_Pagina { get; set; }
        public long Id_Menu { get; set; }
        public bool Activo { get; set; }

    }
}
