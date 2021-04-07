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

        public DataNivelesCertificacion()
        {
            _context = new Carta_vContext();
        }

        public  List<NivelesCertificacion> FindAllNivelesCertificacion()
        {
            return  _context.NivelesCertificacions.ToList();
        }
        public NivelesCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            return _context.NivelesCertificacions.AsNoTracking().SingleOrDefault(us => us.IdNivelCertificacion == idNivelesCertificacion);
        }

        public long AddNivelesCertificacion(NivelesCertificacion NewNivelesCertificacion)
        {
            try
            {
                var NivelesCertificacionRes = _context.NivelesCertificacions.Add(NewNivelesCertificacion);
                _context.SaveChanges();
                return Int32.Parse(NivelesCertificacionRes.Entity.IdNivelCertificacion.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateNivelesCertificacion(NivelesCertificacion editNivelesCertificacion)
        {
            try
            {
                _context.NivelesCertificacions.Update(editNivelesCertificacion);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
