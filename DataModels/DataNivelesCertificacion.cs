using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataNivelesCertificacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataNivelesCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<NivelCertificacion> FindAllNivelesCertificacion()
        {
            return  _context.NivelCertificacions.ToList();
        }
        public NivelCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            return _context.NivelCertificacions.AsNoTracking().SingleOrDefault(us => us.IdNivelCertificacion == idNivelesCertificacion);
        }

        public bool ValidaClaveExistente(string nombreNivelCertificacion)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.NivelCertificacions.AsNoTracking().SingleOrDefault(us => us.NombreNivelCertificacion.Trim().ToUpper() == nombreNivelCertificacion.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public bool ValidaClaveExistente1(int dificultad)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.NivelCertificacions.AsNoTracking().SingleOrDefault(us => us.DificultadNivelCertificacion == dificultad);
            return busqueda == null ? false : true;
        }

        public bool ValidaClaveExistente2(string color)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.NivelCertificacions.AsNoTracking().SingleOrDefault(us => us.Color.Trim().ToUpper() == color.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public long AddNivelesCertificacion(NivelCertificacion item,string ip)
        {
            try
            {
                var NivelesCertificacionRes = _context.NivelCertificacions.Add(item);
                _context.SaveChanges();

                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(NivelesCertificacionRes.Entity.IdNivelCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateNivelesCertificacion(NivelCertificacion item,string ip)
        {
            try
            {
                _context.NivelCertificacions.Update(item);
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
