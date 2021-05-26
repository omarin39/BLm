using System;
using System.Collections.Generic;

#nullable disable

namespace APIRestV2.Models
{
    public partial class ResourceValidacionCampo
    {
        public long IdReglaValidacion { get; set; }
        public string Nombre { get; set; }
        public string TipoDato { get; set; }
        public int TamanioCampo { get; set; }
        public bool? Requerido { get; set; }
        public string Formato { get; set; }
        public int? CodigoErrorRequerido { get; set; }
        public string MensajeErrorRequerido { get; set; }
        public int? CodigoErrorFormato { get; set; }
        public string MensajeErrorFormato { get; set; }
    }
}
