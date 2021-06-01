using APIRestV2.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponseEmpleado
    {
        public long IdPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public List<ResponsePerfilOperacionPermisoJoined> Permisos { get; set; }

    }
}
