using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class VwMaquinaPregunta
    {
        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public bool MaquinaPt { get; set; }
        public int CantidadAccesoMultiple { get; set; }
        public long FabricanteIdFabricante { get; set; }
        public long TipoAccesoIdTipoAcceso { get; set; }
        public bool Activo { get; set; }
        public int? CountPreguntas { get; set; }
        public int? CountProcesos { get; set; }
    }
}
