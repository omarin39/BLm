using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataTipoDocumento
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataTipoDocumento()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<TipoDocumento> FindAllTipoDocumento()
        {
            return  _context.TipoDocumentos.ToList();
        }
        public TipoDocumento FindTipoDocumento(string TipoDocumento)
        {
            return _context.TipoDocumentos.AsNoTracking().SingleOrDefault(us => us.TipoDocumento1 == TipoDocumento);
        }

        public long AddTipoDocumento(TipoDocumento item,string ip)
        {
            try
            {
                var TipoDocumentoRes = _context.TipoDocumentos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(TipoDocumentoRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateTipoDocumento(TipoDocumento item,string ip)
        {
            try
            {
                _context.TipoDocumentos.Update(item);
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
