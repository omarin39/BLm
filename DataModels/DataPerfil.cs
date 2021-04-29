using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPerfil
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPerfil()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Perfile> FindAllPerfil()
        {
            return  _context.Perfiles.ToList();
        }
        public Perfile FindPerfil(long idPerfil)
        {
            return _context.Perfiles.AsNoTracking().SingleOrDefault(us => us.Id == idPerfil);
        }

        public long AddPerfil(Perfile item,string ip)
        {
            try
            {
                var perfilRes = _context.Perfiles.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(perfilRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePerfil(Perfile item,string ip)
        {
            try
            {
                _context.Perfiles.Update(item);
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
