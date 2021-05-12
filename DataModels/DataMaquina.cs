using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMaquina
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataMaquina()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<VwMaquinaPregunta> FindAllMaquina()
        {
            return _context.VwMaquinaPreguntas.ToList();
        }
       


       public VwMaquinaPregunta findPiezaPorIdPieza(long id)
        {
            return _context.VwMaquinaPreguntas.AsNoTracking().SingleOrDefault(p => p.IdMaquina == id);
        }

        public long AddMaquina(Maquina item,string ip)
        {
            try
            {
                var PiezaRes = _context.Maquinas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateMaquina(Maquina item, string ip)
        {
            try
            {
                _context.Maquinas.Update(item);
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
