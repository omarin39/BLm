using APIRestV2.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponsePerfilOperacionPermisoJoined
    {
        public long Id { get; set; }
        public long IdOperacion { get; set; }
        public String Operacion { get; set; }
        public bool Crear { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }


    }
}
