using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataCertificacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Certificacion> FindAllCertificacions()
        {
            return  _context.Certificacions.ToList();
        }
        public Certificacion FindCertificacion(long idCertificacion)
        {
            return _context.Certificacions.AsNoTracking().SingleOrDefault(us => us.IdCertificacion == idCertificacion);
        }

        public long AddCertificacion(Certificacion newItem, String ip)
        {
            try
            {
                var CertificacionRes = _context.Certificacions.Add(newItem);
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(CertificacionRes.Entity.IdCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCertificacion(Certificacion item, String ip)
        {
            try
            {
                _context.Certificacions.Update(item);
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
