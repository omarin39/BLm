using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Models.Request
{
    public class RequestPerfilOperacionPermiso
    {
        public long Id { get; set; }
        public long IdPerfil { get; set; }
        public long IdOperacion { get; set; }
        public bool Crear { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }
        

    }
}
