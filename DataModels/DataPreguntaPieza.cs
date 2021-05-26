using APIRestV2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataPreguntaPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaPieza> findAllPreguntaPieza()
        {
            return _context.PreguntaPiezas.ToList();
        }

        public PreguntaPieza findPreguntaPiezaIdPreguntaPieza(long id)
        {
            return _context.PreguntaPiezas.AsNoTracking().SingleOrDefault(us => us.IdPreguntaPieza == id);
        }

        public List<PreguntaPieza> findPreguntaPiezaIdProcesoPiezaMaquina(long id)
        {
            var preguntas = _context.PreguntaPiezas.Where(us => us.ProcesoPiezaMaquinaIdProcesoPiezaMaquina == id);
            return preguntas.ToList();
        }

        public long AddPreguntaPieza(PreguntaPieza item, string ip)
        {
            try
            {
                var PreguntaPiezaRes = _context.PreguntaPiezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaPiezaRes.Entity.IdPreguntaPieza.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaPieza(PreguntaPieza item, string ip)
        {
            try
            {
                _context.PreguntaPiezas.Update(item);
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
