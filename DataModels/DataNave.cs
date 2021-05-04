
using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataNave
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        private Models.Request.RequestLog rlog;

        public DataNave()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
            rlog = new Models.Request.RequestLog();
        }

        public List<Nave> FindAllNaves()
        {
            return  _context.Naves.Include("LineaProduccions").ToList();
        }
        public Nave FindNave(long Nave)
        {
            return _context.Naves.AsNoTracking().SingleOrDefault(us => us.IdNave == Nave);
        }
        public List<Nave> FindNavePlanta(long Nave)
        {
            return _context.Naves.Include("LineaProduccions").Where(us => us.PlantaIdPlanta == Nave).ToList();
        }

        public long AddNave(Nave NewNave, String ip)
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
        public int UpdateNave(Nave _Nave, String ip)
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

        public List<Nave> FindAllNavesPorPlanta(long idPlanta)
        {
            var naves = _context.Naves.Where(us => us.PlantaIdPlanta == idPlanta);
            return naves.ToList();   
        }

        public List<LineaProduccion> FindAllNavesPorLineaProduccion(long id, String ip)
        {
            var naves = _context.LineaProduccions.Where(us => us.IdNave == id);
            return naves.ToList();

        }
    }
}
