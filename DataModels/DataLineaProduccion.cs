using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataLineaProduccion
    {
        private readonly Carta_vContext _context;

        public DataLineaProduccion()
        {
            _context = new Carta_vContext();
        }

        public List<LineasProduccion> FindAllLineaProduccions()
        {
            return  _context.LineasProduccions.Include("Naves").ToList();
        }
        public LineasProduccion FindLineaProduccion(long idLineaProduccionExt)
        {
            return _context.LineasProduccions.AsNoTracking().SingleOrDefault(us => us.Id == idLineaProduccionExt);
        }

        public long AddLineaProduccion(LineasProduccion NewLineaProduccion)
        {
            try
            {
                var LineaProduccionRes = _context.LineasProduccions.Add(NewLineaProduccion);
                _context.SaveChanges();
                return Int32.Parse(LineaProduccionRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateLineaProduccion(LineasProduccion _LineaProduccion)
        {
            try
            {
                _context.LineasProduccions.Update(_LineaProduccion);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        
    }
}
