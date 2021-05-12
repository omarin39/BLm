using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Request
{
    public class RequestMaquina
    {
        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public bool MaquinaPt { get; set; }
        public int CantidadAccesoMultiple { get; set; }
        public long FabricanteIdFabricante { get; set; }
        public long? TipoAccesoIdTipoAcceso { get; set; }
        public bool? Activo { get; set; }

    }
}
