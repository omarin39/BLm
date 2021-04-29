using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataLineaProduccion
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataLineaProduccion()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<LineasProduccion> FindAllLineaProduccions()
        {
            return  _context.LineasProduccions.ToList();
        }
        public LineasProduccion FindLineaProduccion(long idLineaProduccionExt)
        {
            return _context.LineasProduccions.AsNoTracking().SingleOrDefault(us => us.Id == idLineaProduccionExt);
        }

        public LineasProduccion FindLineaProduccionNave(long idLineaProduccionExt)
        {
            return _context.LineasProduccions.AsNoTracking().SingleOrDefault(us => us.IdNave == idLineaProduccionExt);
        }



        public long AddLineaProduccion(LineasProduccion item,string ip)
        {
            try
            {
                var LineaProduccionRes = _context.LineasProduccions.Add(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(LineaProduccionRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateLineaProduccion(LineasProduccion item,string ip)
        {
            try
            {
                _context.LineasProduccions.Update(item);
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
