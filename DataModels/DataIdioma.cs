using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataIdioma
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataIdioma()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Idioma> FindAllIdioma()
        {
            return _context.Idiomas.ToList();
        }
        public Idioma FindIdioma(long idIdioma)
        {
            return _context.Idiomas.AsNoTracking().SingleOrDefault(us => us.IdIdioma == idIdioma);
        }

        public long AddIdioma(Idioma item,string ip)
        {
            try
            {
                var idiomaRes = _context.Idiomas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(idiomaRes.Entity.IdIdioma.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                //var r = ex.InnerException.Message;
                //return 0;
                throw new Exception(ex.InnerException.Message);
            }
        }

        public int UpdateIdioma(Idioma item,string ip)
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
    }
}
