using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataCentroCosto
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataCentroCosto()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public async Task<List<CentroCosto>> FindAllCECO()
        {
            return await _context.CentroCostos.ToListAsync();

        }

        public CentroCosto FindCECO(string FindCECO)
        {
            CentroCosto resultadoBusqueda = new();
            resultadoBusqueda = _context.CentroCostos.AsNoTracking().SingleOrDefault(ce => ce.DescCentroCosto == FindCECO);
            return resultadoBusqueda;
        }

        public long AddCECO(CentroCosto item,string ip)
        {
            try
            {
                var CECORes = _context.CentroCostos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(CECORes.Entity.IdCentroCosto.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }
        }

        public long UpdateCECO(CentroCosto item, string ip)
        {
            try
            {
                _context.CentroCostos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
