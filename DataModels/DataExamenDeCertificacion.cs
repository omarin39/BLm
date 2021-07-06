using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataExamenDeCertificacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataExamenDeCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public long AddExamenCertificacion(ExamenDeCertificacion item, string ip)
        {
            try
            {
                var ExamenCertificacionResp= _context.ExamenDeCertificacions.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ExamenCertificacionResp.Entity.IdExamenCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateExamenCertificacion(ExamenDeCertificacion item, string ip)
        {
            try
            {
                _context.ExamenDeCertificacions.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        public ExamenDeCertificacion FindOnlyExamenCertificaPorId(long id)
        {
            return _context.ExamenDeCertificacions.AsNoTracking().SingleOrDefault(p => p.IdExamenCertificacion== id);
        }

    }
}
