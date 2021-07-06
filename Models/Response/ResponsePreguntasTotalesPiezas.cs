using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Models.Response
{
    public class ResponsePreguntasTotalesPiezas
    {
        public long IdGlobal { get; set; }
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int Orden { get; set; }
        public long IdProcesoPiezaMaquina { get; set; }
        public long IdIdioma { get; set; }
        public long IdNivelCertificacion { get; set; }
        public bool IsGral { get; set; }
    }
}
