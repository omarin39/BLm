using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataOperacion
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataOperacion()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Operacione> FindAllOperacion()
        {
            return  _context.Operaciones.ToList();
        }
        public Operacione FindOperacion(long idOperacion)
        {
            return _context.Operaciones.AsNoTracking().SingleOrDefault(us => us.Id == idOperacion);
        }

        public long AddOperacion(Operacione item,string ip)
        {
            try
            {
                var OperacionRes = _context.Operaciones.Add(item);
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

        public int UpdateOperacion(Operacione item,string ip)
        {
            try
            {
                _context.Operaciones.Update(item);
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
