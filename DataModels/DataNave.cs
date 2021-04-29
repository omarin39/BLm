
using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataNave
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        private Models.Request.RequestLog rlog;

        public DataNave()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
            rlog = new Models.Request.RequestLog();
        }

        public List<Nafe> FindAllNaves()
        {
            return  _context.Naves.ToList();
        }
        public Nafe FindNave(string Nave)
        {
            return _context.Naves.AsNoTracking().SingleOrDefault(us => us.Nombre == Nave);
        }
        public List<Nafe> FindNavePlanta(string Nave)
        {
            return _context.Naves.Where(us => us.PlantasIdPlanta == long.Parse(Nave)).ToList();
        }

        public long AddNave(Nafe NewNave, String ip)
        {
            try
            {
                var NaveRes = _context.Naves.Add(NewNave);
                _context.SaveChanges();

              
                procLog.AddLog(ip,procLog.GetPropertyValues(NewNave, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(NaveRes.Entity.IdNave.ToString());
            }
            catch (Exception ex)
            {

                procLog.AddLog(ip, procLog.GetPropertyValues(NewNave, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateNave(Nafe _Nave, String ip)
        {
            try
            {
                _context.Naves.Update(_Nave);
                procLog.AddLog(ip, procLog.GetPropertyValues(_Nave, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(_Nave, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }

        public List<Nafe> FindAllNavesPorPlanta(long idPlanta)
        {
            var naves = _context.Naves.Where(us => us.PlantasIdPlanta == idPlanta);
            return naves.ToList();   
        }

        public List<LineasProduccion> FindAllNavesPorLineaProduccion(long id, String ip)
        {
            var naves = _context.LineasProduccions.Where(us => us.IdNave == id);
            return naves.ToList();

        }
    }
}
