using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataEmpleado
    {
        private readonly Carta_vContext _context;

        public DataEmpleado()
        {
            _context = new Carta_vContext();
        }

        public  List<Empleado> FindAllEmpleado()
        {
            return  _context.Empleados.ToList();
        }
        public Empleado FindEmpleado(long idEmpleado)
        {
            return _context.Empleados.AsNoTracking().SingleOrDefault(us => us.IdEmpleado == idEmpleado);
        }

        public long AddEmpleado(Empleado NewEmpleado)
        {
            try
            {
                var empleadoRes = _context.Empleados.Add(NewEmpleado);
                _context.SaveChanges();
                return Int32.Parse(empleadoRes.Entity.IdEmpleado.ToString());
            }
            catch (Exception ex)
            {

                //var r = ex.InnerException.Message;
                //return 0;
                throw new Exception(ex.InnerException.Message);
            }
        }

        public int UpdateEmpleado(Empleado editEmpleado)
        {
            try
            {
                _context.Empleados.Update(editEmpleado);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
