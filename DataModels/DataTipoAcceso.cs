using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataTipoAcceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataTipoAcceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<TipoAcceso> FindAllTipoAcceso()
        {
           
            return _context.TipoAccesos.ToList();
          
        }
       


       public TipoAcceso findPiezaPorIdPieza(long id)
        {
            return _context.TipoAccesos.AsNoTracking().SingleOrDefault(p => p.IdTipoAcceso == id);
        }

        public long AddTipoAcceso(TipoAcceso item,string ip)
        {
            try
            {
                var PiezaRes = _context.TipoAccesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdTipoAcceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateTipoAcceso(TipoAcceso item, string ip)
        {
            try
            {
                _context.TipoAccesos.Update(item);
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
