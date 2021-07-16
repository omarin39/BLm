using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataOpProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataOpProceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<OperacionProceso> FindAllProcesos()
        {
            return  _context.OperacionProcesos.ToList();
        }
        public OperacionProceso FindProceso(string Proceso)
        {
            return _context.OperacionProcesos.AsNoTracking().SingleOrDefault(us => us.Codigo == Proceso);
        }

        public bool ValidaClaveExistente(RequestOpProceso Proceso)
        {
            //true si existe
            //false si no existe
           var busqueda = _context.OperacionProcesos.AsNoTracking().SingleOrDefault(us => us.Codigo.Trim().ToUpper() == Proceso.Codigo.Trim().ToUpper() && us.IdProceso != Proceso.IdProceso);
            return busqueda==null ? false : true;
        }

        public long AddProceso(OperacionProceso item,string ip)
        {
            try
            {
                var ProcesoRes = _context.OperacionProcesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ProcesoRes.Entity.IdProceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateProceso(OperacionProceso item,string ip)
        {
            try
            {
                _context.OperacionProcesos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        internal List<OperacionProceso> FindProcesoAutoComplete(string param)
        {
            param = param.ToUpper().Replace("%2F", "/").Trim();
            return _context.OperacionProcesos.Where(p => p.Codigo.ToUpper().Contains(param) || p.Nombre.ToUpper().Contains(param)).Take(200).ToList();

        }
    }
}
