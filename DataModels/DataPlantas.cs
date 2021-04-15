using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPlantas
    {
        private readonly Carta_vContext _context;

        public DataPlantas()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<Planta>> FindAllPlantas()
        {
            return await _context.Plantas.ToListAsync();
        }
        public Planta FindPlanta(string Planta)
        {
            return _context.Plantas.AsNoTracking().SingleOrDefault(us => us.Acronimo == Planta);
        }

        public long AddPlanta(Planta NewPlanta)
        {
            try
            {
                var plantaRes = _context.Plantas.Add(NewPlanta);
                _context.SaveChanges();
                return Int32.Parse(plantaRes.Entity.IdPlanta.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePlanta(Planta _planta)
        {
            try
            {
                _context.Plantas.Update(_planta);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
