using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataNivelesCertificacion
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataNivelesCertificacion()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<NivelesCertificacion> FindAllNivelesCertificacion()
        {
            return  _context.NivelesCertificacions.ToList();
        }
        public NivelesCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            return _context.NivelesCertificacions.AsNoTracking().SingleOrDefault(us => us.IdNivelCertificacion == idNivelesCertificacion);
        }

        public long AddNivelesCertificacion(NivelesCertificacion item,string ip)
        {
            try
            {
                var NivelesCertificacionRes = _context.NivelesCertificacions.Add(item);
                _context.SaveChanges();

                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(NivelesCertificacionRes.Entity.IdNivelCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateNivelesCertificacion(NivelesCertificacion item,string ip)
        {
            try
            {
                _context.NivelesCertificacions.Update(item);
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
