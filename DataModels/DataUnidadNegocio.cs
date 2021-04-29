using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataUnidadNegocio
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataUnidadNegocio()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public async Task<List<UnidadNegocio>> FindAllUnidadNegocio() {
            return await _context.UnidadNegocios.ToListAsync();
        }
        public UnidadNegocio FindUnidadNegocio(string unidadNegocio){
            UnidadNegocio ResultadoUnidad = _context.UnidadNegocios.AsNoTracking().SingleOrDefault(uN => uN.DescUnidadNegocio == unidadNegocio);
            return ResultadoUnidad;
        }
        public long AddUnidadNeg(UnidadNegocio item,string ip)
        {
            try
            {
                var respUnidad = _context.UnidadNegocios.Add(item);
                _context.SaveChanges();

                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(respUnidad.Entity.IdUnidadNegocio.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }
        }

        public long UpdateUnidaddNeg(UnidadNegocio item,string ip)//(long id_puestoExterno, string nombrePuesto)
        {
            try
            {
                _context.UnidadNegocios.Update(item);
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
