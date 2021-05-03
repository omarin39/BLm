using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataDepartamentos
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataDepartamentos()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public async Task<List<Departamento>> FindAllDepartamentos()
        {

            return await _context.Departamentos.ToListAsync();
        }
        public Departamento FindDepartamento(int tipoBusqueda, long id_depaExterno, string nombreDepa)
        {
            Departamento resultadobusqueda = new();
            switch (tipoBusqueda)
            {
                case 1:
                    resultadobusqueda = _context.Departamentos.AsNoTracking().SingleOrDefault(us => us.IdDepartamentExterno == id_depaExterno);
                    break;
                case 2:
                    resultadobusqueda = _context.Departamentos.AsNoTracking().SingleOrDefault(us => us.Departamento1 == nombreDepa);
                    break;
                default:
                    break;
            }
            return resultadobusqueda;
        }

        public long AddDepartamento(Departamento item,string ip)
        {
            try
            {
                var departamentoRes = _context.Departamentos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(departamentoRes.Entity.IdDepartamento.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r =  ex.Message;
                return 0;
            }
            
        }

        public long UpdateDepartamento(Departamento item,string ip)
        {
            try
            {
                _context.Departamentos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0; ;
            }

        }

    }
}
