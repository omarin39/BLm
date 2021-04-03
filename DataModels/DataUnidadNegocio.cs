using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataUnidadNegocio
    {
        private readonly Carta_vContext _context;

        public DataUnidadNegocio()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<UnidadNegocio>> FindAllUnidadNegocio() {
            return await _context.UnidadNegocios.ToListAsync();
        }
        public UnidadNegocio FindUnidadNegocio(string unidadNegocio){
            UnidadNegocio ResultadoUnidad = _context.UnidadNegocios.AsNoTracking().SingleOrDefault(uN => uN.DescUnidadNegocio == unidadNegocio);
            return ResultadoUnidad;
        }
        public long AddUnidadNeg(UnidadNegocio NewUnidad)
        {
            var respUnidad = _context.UnidadNegocios.Add(NewUnidad);
            _context.SaveChanges();
            return Int32.Parse(respUnidad.Entity.IdUnidadNegocio.ToString());
        }

        public long UpdateUnidaddNeg(UnidadNegocio _Unegocio)//(long id_puestoExterno, string nombrePuesto)
        {
            try
            {
                _context.UnidadNegocios.Update(_Unegocio);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0; ;
            }
        }
    }
}
