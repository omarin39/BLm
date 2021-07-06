using APIRestV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataResultadoProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataResultadoProceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public long AddDataResultadoProcesoExamenCertifica(ResultadoProceso item, string ip)
        {
            try
            {
                var ResultadoProcesoResp = _context.ResultadoProcesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ResultadoProcesoResp.Entity.IdResultadoProceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
    }
}
