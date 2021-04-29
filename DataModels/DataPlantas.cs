using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPlantas
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPlantas()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public async Task<List<Planta>> FindAllPlantas()
        {
            return await _context.Plantas.ToListAsync();
        }
        public Planta FindPlanta(string Planta)
        {
            return _context.Plantas.AsNoTracking().SingleOrDefault(us => us.Acronimo == Planta);
        }

        public long AddPlanta(Planta item,string ip)
        {
            try
            {
                var plantaRes = _context.Plantas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(plantaRes.Entity.IdPlanta.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePlanta(Planta item,string ip)
        {
            try
            {
                _context.Plantas.Update(item);
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
