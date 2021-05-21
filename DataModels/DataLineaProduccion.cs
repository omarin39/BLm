using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataLineaProduccion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataLineaProduccion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<LineaProduccion> FindAllLineaProduccions()
        {
            return  _context.LineaProduccions.ToList();
        }
        public LineaProduccion FindLineaProduccion(long idLineaProduccionExt)
        {
            return _context.LineaProduccions.AsNoTracking().SingleOrDefault(us => us.Id == idLineaProduccionExt);
        }

        public List<LineaProduccion> FindLineaProduccionNave(long idNave)
        {
            return _context.LineaProduccions.AsNoTracking().Where(us => us.IdNave == idNave).ToList();
        }



        public long AddLineaProduccion(LineaProduccion item,string ip)
        {
            try
            {
                var LineaProduccionRes = _context.LineaProduccions.Add(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(LineaProduccionRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateLineaProduccion(LineaProduccion item,string ip)
        {
            try
            {
                _context.LineaProduccions.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        public bool FindNombreLProduccion(RequestLineaProduccion BusquedaVar)
        {
            LineaProduccion busqueda = new();
            busqueda = _context.LineaProduccions.AsNoTracking().SingleOrDefault(us => us.NombreLinea.Trim().ToUpper() == BusquedaVar.NombreLinea.Trim().ToUpper() && us.Id != BusquedaVar.Id);
            return busqueda == null ? false : true;
        }


    }
}
