using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataEmpleados
    {
        private readonly Carta_vContext _context;

        public DataEmpleados()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<Empleado>> FindAllEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }
        public Empleado FindEmpleado(string noNomina)
        {
            return _context.Empleados.AsNoTracking().SingleOrDefault(us => us.NNomina == noNomina);
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

                var r = ex.Message;
                return 0; ;
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
