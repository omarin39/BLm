using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataCertificacion
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataCertificacion()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Certificacione> FindAllCertificacions()
        {
            return  _context.Certificaciones.ToList();
        }
        public Certificacione FindCertificacion(long idCertificacion)
        {
            return _context.Certificaciones.AsNoTracking().SingleOrDefault(us => us.IdCertificacion == idCertificacion);
        }

        public long AddCertificacion(Certificacione newItem, String ip)
        {
            try
            {
                var CertificacionRes = _context.Certificaciones.Add(newItem);
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(CertificacionRes.Entity.IdCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCertificacion(Certificacione item, String ip)
        {
            try
            {
                _context.Certificaciones.Update(item);
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
