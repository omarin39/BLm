using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataCentroCosto
    {
        private readonly Carta_vContext _context;

        public DataCentroCosto()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<CentroCosto>> FindAllCECO()
        {
            return await _context.CentroCostos.ToListAsync();

        }

        public CentroCosto FindCECO(string FindCECO)
        {
            CentroCosto resultadoBusqueda = new();
            resultadoBusqueda = _context.CentroCostos.AsNoTracking().SingleOrDefault(ce => ce.DescCentroCosto == FindCECO);
            return resultadoBusqueda;
        }

        public long AddCECO(CentroCosto NewCECO)
        {
            try
            {
                var CECORes = _context.CentroCostos.Add(NewCECO);
                _context.SaveChanges();
                return Int32.Parse(CECORes.Entity.IdCentroCosto.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public long UpdateCECO(CentroCosto _CECO)
        {
            try
            {
                _context.CentroCostos.Update(_CECO);
                return _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
