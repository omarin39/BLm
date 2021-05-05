using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataFabricante
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataFabricante()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Fabricante> FindAllFabricante()
        {
            return  _context.Fabricantes.ToList();
        }
        public Fabricante FindFabricante(long idFabricante)
        {
            return _context.Fabricantes.AsNoTracking().SingleOrDefault(us => us.IdFabricante == idFabricante);
        }

        public long AddFabricante(Fabricante item,string ip)
        {
            try
            {
                var FabricanteRes = _context.Fabricantes.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(FabricanteRes.Entity.IdFabricante.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateFabricante(Fabricante item,string ip)
        {
            try
            {
                _context.Fabricantes.Update(item);
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
