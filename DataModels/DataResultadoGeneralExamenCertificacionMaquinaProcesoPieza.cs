using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataResultadoGeneralExamenCertificacionMaquinaProcesoPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataResultadoGeneralExamenCertificacionMaquinaProcesoPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public long AddDataResultadoGeneralExamenCertificacionMaquinaProcesoPieza(ResultadoGeneralExamenCertificacionMaquinaProcesoPieza item, string ip)
        {
            try
            {
                var ResultadoGralPaquinaProcesoPiezaResp = _context.ResultadoGeneralExamenCertificacionMaquinaProcesoPiezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ResultadoGralPaquinaProcesoPiezaResp.Entity.IdResultadoGeneral.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public List<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza> FindResultadoGralExamenCertifica(long IdExamenCertificacion, long TipoPregunta, long IdIdioma)
        {
            return _context.ResultadoGeneralExamenCertificacionMaquinaProcesoPiezas.AsNoTracking().Where(us => us.IdExamenCertificacion == IdExamenCertificacion && us.TipoPregunta == TipoPregunta && us.IdIdioma == IdIdioma && us.Activo==true).ToList();
        }

    }
}
