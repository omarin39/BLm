﻿using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataEmpleado
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataEmpleado()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Empleado> FindAllEmpleado()
        {
            return  _context.Empleados.ToList();
        }
        public Empleado FindEmpleado(long idEmpleado)
        {
            return _context.Empleados.SingleOrDefault(us => us.IdEmpleado == idEmpleado);
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
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                throw new Exception(ex.InnerException.Message);
            }
        }

        public int UpdateEmpleado(Empleado item,string ip)
        {
            try
            {
                //_context.Empleados.Update(editEmpleado);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }

        internal List<Empleado> FindAllEmpleadosPorPerfil(long idPerfil)
        {
            var empleados= _context.Empleados.Where(us => us.IdPerfil == idPerfil);
           
            return empleados.ToList();
        }
    }
}
