using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataProceso
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataProceso()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Proceso> FindAllProcesos()
        {
            return  _context.Procesos.ToList();
        }
        public Proceso FindProceso(string Proceso)
        {
            return _context.Procesos.AsNoTracking().SingleOrDefault(us => us.Codigo == Proceso);
        }

        public long AddProceso(Proceso item,string ip)
        {
            try
            {
                var ProcesoRes = _context.Procesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ProcesoRes.Entity.IdProceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateProceso(Proceso item,string ip)
        {
            try
            {
                _context.Procesos.Update(item);
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
