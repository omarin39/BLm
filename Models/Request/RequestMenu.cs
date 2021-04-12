using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestMenu
    {
        public long Id { get; set; }
        public string NombreMenu { get; set; }
        public bool Activo { get; set; }

        public ICollection<Operacione> Operaciones { get; set; }
    }
}
