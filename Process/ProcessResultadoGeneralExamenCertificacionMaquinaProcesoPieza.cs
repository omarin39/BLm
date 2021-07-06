using APIRestV2.DataModels;
using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Process
{
    public class ProcessResultadoGeneralExamenCertificacionMaquinaProcesoPieza
    {
        public DataResultadoGeneralExamenCertificacionMaquinaProcesoPieza ExamenResultadoGral = new();
        public List<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza> FindResultadoGralExamenCertifica(long IdExamenCertificacion, long TipoPregunta, long IdIdioma)
        {
            return ExamenResultadoGral.FindResultadoGralExamenCertifica(IdExamenCertificacion, TipoPregunta, IdIdioma);
        }
    }
}
