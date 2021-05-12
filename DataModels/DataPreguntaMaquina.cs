using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaMaquina
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPreguntaMaquina()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaMaquina> FindAllPreguntaMaquina()
        {
           
            return _context.PreguntaMaquinas.ToList();
          
        }
       


       public PreguntaMaquina findPiezaPorIdPieza(long id)
        {
            return _context.PreguntaMaquinas.AsNoTracking().SingleOrDefault(p => p.IdPreguntaMaquina == id);
        }

        public long AddPreguntaMaquina(PreguntaMaquina item,string ip)
        {
            try
            {
                var PiezaRes = _context.PreguntaMaquinas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdPreguntaMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaMaquina(PreguntaMaquina item, string ip)
        {
            try
            {
                _context.PreguntaMaquinas.Update(item);
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
