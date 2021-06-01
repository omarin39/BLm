using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaGeneral
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPreguntaGeneral()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaGeneral> FindAllPreguntas()
        {
            return _context.PreguntaGenerals.ToList();
        }
        public List<PreguntaGeneral> FindPreguntasByTipo(long tipo)
        {
            return _context.PreguntaGenerals.Where(us => us.TipoPreguntaIdTipoPregunta == tipo).ToList();
        }
        public PreguntaGeneral FindPregunta(long Id)
        {
            return _context.PreguntaGenerals.AsNoTracking().SingleOrDefault(us => us.IdPreguntaGeneral == Id);
        }

        public long AddPregunta(PreguntaGeneral item, string ip)
        {
            try
            {
                var PreguntaRes = _context.PreguntaGenerals.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaRes.Entity.IdPreguntaGeneral.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePregunta(PreguntaGeneral item, string ip)
        {
            try
            {
                _context.PreguntaGenerals.Update(item);
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
