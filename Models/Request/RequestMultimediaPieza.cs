using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestMultimediaPieza
    {

        public long Id { get; set; }
        public long IdPieza { get; set; }
        public long IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public bool? Recertificacion { get; set; }
        public string Ruta { get; set; }
        public string TipoMedia { get; set; }
        public bool Activo { get; set; }
        public List<IFormFile> documento { set; get; }


    }


}
