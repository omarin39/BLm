using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestPerfilOperacionPermisoItem
    {
        
        public long IdPerfil { get; set; }
        public long IdOpercion { get; set; }
        public bool Crear { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Ver { get; set; }
        

    }
}
