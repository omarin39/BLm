using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataProceso()
        {
            _context = new CARTAVContext();
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

        public bool ValidaClaveExistente(RequestProceso Proceso)
        {
            //true si existe
            //false si no existe
           var busqueda = _context.Procesos.AsNoTracking().SingleOrDefault(us => us.Codigo.Trim().ToUpper() == Proceso.Codigo.Trim().ToUpper() && us.IdProceso != Proceso.IdProceso);
            return busqueda==null ? false : true;
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
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
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
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        internal List<Proceso> FindProcesoAutoComplete(string param)
        {
            param = param.ToUpper().Replace("%2F", "/").Trim();
            return _context.Procesos.Where(p => p.Codigo.ToUpper().Contains(param) || p.Nombre.ToUpper().Contains(param)).Take(200).ToList();

        }
    }
}
