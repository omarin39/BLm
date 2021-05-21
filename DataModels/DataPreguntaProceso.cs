using APIRestV2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataPreguntaProceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaProceso> findAllPreguntaProceso()
        {
            return _context.PreguntaProcesos.ToList();
        }

        public PreguntaProceso findPreguntaProcesoIdPreguntaProceso(long id)
        {
            return _context.PreguntaProcesos.AsNoTracking().SingleOrDefault(us => us.IdPreguntaProceso == id);
        }

        public List<PreguntaProceso> findPreguntaProcesoIdProceso(long id)
        {
            var preguntas = _context.PreguntaProcesos.Where(us => us.ProcesoIdProceso == id);
            return preguntas.ToList();
        }

        public long AddPreguntaProceso(PreguntaProceso item, string ip)
        {
            try
            {
                var PreguntaProcesoRes = _context.PreguntaProcesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaProcesoRes.Entity.IdPreguntaProceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaProceso(PreguntaProceso item, string ip)
        {
            try
            {
                _context.PreguntaProcesos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }
    }
}
