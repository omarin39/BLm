using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataCapacitacionEmpleado
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataCapacitacionEmpleado()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<CapacitacionEmpleado> FindAllCapacitacionEmpleado()
        {
            return  _context.CapacitacionEmpleados.ToList();
        }
        public CapacitacionEmpleado FindProceso(long idEmpleado)
        {
            return _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(us => us.IdEmpleado == idEmpleado);
        }

        /*public bool ValidaClaveExistente(RequestCapacitacionEmpleado inputItem)
        {
            //true si existe
            //false si no existe
           var busqueda = _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(us => us.IdEmpleado .Trim().ToUpper() == Proceso.Codigo.Trim().ToUpper() && us.IdProceso != Proceso.IdProceso);
            return busqueda==null ? false : true;
        }*/

        public long Addentity(CapacitacionEmpleado item,string ip)
        {
            try
            {
                var objRes = _context.CapacitacionEmpleados.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(objRes.Entity.IdCapacitacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCpacitacionEmpleado(CapacitacionEmpleado item,string ip)
        {
            try
            {
                _context.CapacitacionEmpleados.Update(item);
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
