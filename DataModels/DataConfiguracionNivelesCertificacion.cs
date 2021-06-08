using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataConfiguracionNivelesCertificacion
    {
        private readonly CARTAVContext _context;
        private readonly Controllers.Process.Process_Log procLog;

        public DataConfiguracionNivelesCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<ConfiguracionNivelCertificacion> FindAllConfiguracionNivelesCertificacion()
        {
            return _context.ConfiguracionNivelCertificacions.AsNoTracking().ToList();
        }
        public ConfiguracionNivelCertificacion FindById(long Id)
        {
            return _context.ConfiguracionNivelCertificacions.AsNoTracking().SingleOrDefault(cn=> cn.IdConfiguraNivelCertifica == Id);
        }

        public ConfiguracionNivelCertificacion FindByIdNivelCertificacion(long Id)
        {
            return _context.ConfiguracionNivelCertificacions.AsNoTracking().SingleOrDefault(cn => cn.IdNivelCertificacion == Id);
        }

        public long AddConfiguracionNivelesCertificacion(ConfiguracionNivelCertificacion item, string ip)
        {
            try
            {
                var ConfigNivelesCertificacionRes = _context.ConfiguracionNivelCertificacions.Add(item);
                _context.SaveChanges();

                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ConfigNivelesCertificacionRes.Entity.IdConfiguraNivelCertifica.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateConfiguracionNivelesCertificacion(ConfiguracionNivelCertificacion item, string ip)
        {
            try
            {
                _context.ConfiguracionNivelCertificacions.Update(item);
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
