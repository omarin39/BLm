using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataOperacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataOperacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Operacion> FindAllOperacion()
        {
            return  _context.Operacions.ToList();
        }
        public Operacion FindOperacion(long idOperacion)
        {
            return _context.Operacions.AsNoTracking().SingleOrDefault(us => us.Id == idOperacion);
        }

        public long AddOperacion(Operacion item,string ip)
        {
            try
            {
                var OperacionRes = _context.Operacions.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(OperacionRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateOperacion(Operacion item,string ip)
        {
            try
            {
                _context.Operacions.Update(item);
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
