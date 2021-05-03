using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaPtGeneral
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPreguntaPtGeneral()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaPtGeneral> FindAllPreguntas()
        {
            return  _context.PreguntaPtGenerals.ToList();
        }
        public PreguntaPtGeneral FindPregunta(string Pregunta)
        {
            return _context.PreguntaPtGenerals.AsNoTracking().SingleOrDefault(us => us.Pregunta == Pregunta);
        }

        public long AddPregunta(PreguntaPtGeneral item,string ip)
        {
            try
            {
                var PreguntaRes = _context.PreguntaPtGenerals.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaRes.Entity.IdPreguntaPt.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePregunta(PreguntaPtGeneral item,string ip)
        {
            try
            {
                _context.PreguntaPtGenerals.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }
    }
}
