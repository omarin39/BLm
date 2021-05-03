using APIRestV2.Models;
using System.Collections.Generic;

namespace APIRestV2.Models.Request
{
    public class RequestMenu
    {
        public long Id { get; set; }
        public string NombreMenu { get; set; }
        public bool Activo { get; set; }

        public ICollection<Operacion> Operaciones { get; set; }
    }
}
