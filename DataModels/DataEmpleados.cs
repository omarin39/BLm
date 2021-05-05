using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataEmpleados
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataEmpleados()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public async Task<List<Empleado>> FindAllEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }
        public Empleado FindEmpleado(string noNomina)
        {
            return _context.Empleados.SingleOrDefault(us => us.NumeroNomina == noNomina);
        }

        public long AddEmpleado(Empleado item,string ip)
        {
            try
            {
                var empleadoRes = _context.Empleados.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(empleadoRes.Entity.IdEmpleado.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0; ;
            }
        }

        public int UpdateEmpleado(Empleado item,string ip)
        {
            try
            {
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
