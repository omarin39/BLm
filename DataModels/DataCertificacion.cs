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

        public DataCertificacion()
        {
            _context = new Carta_vContext();
        }

        public List<Certificacione> FindAllCertificacions()
        {
            return  _context.Certificaciones.ToList();
        }
        public Certificacione FindCertificacion(long idCertificacion)
        {
            return _context.Certificaciones.AsNoTracking().SingleOrDefault(us => us.IdCertificacion == idCertificacion);
        }

        public long AddCertificacion(Certificacione NewCertificacion)
        {
            try
            {
                var CertificacionRes = _context.Certificaciones.Add(NewCertificacion);
                _context.SaveChanges();
                return Int32.Parse(CertificacionRes.Entity.IdCertificacion.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCertificacion(Certificacione _Certificacion)
        {
            try
            {
                _context.Certificaciones.Update(_Certificacion);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
