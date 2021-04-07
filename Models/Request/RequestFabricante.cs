using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestFabricante
    {
        public long Id_fabricante { get; set; }
        public String nombre { get; set; }
        public String contacto { get; set; }
        public String email { get; set; }
        public String telefono { get; set; }

    }
}
