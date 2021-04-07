using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataFabricante
    {
        private readonly Carta_vContext _context;

        public DataFabricante()
        {
            _context = new Carta_vContext();
        }

        public  List<Fabricante> FindAllFabricante()
        {
            return  _context.Fabricantes.ToList();
        }
        public Fabricante FindFabricante(long idFabricante)
        {
            return _context.Fabricantes.AsNoTracking().SingleOrDefault(us => us.IdFabricante == idFabricante);
        }

        public long AddFabricante(Fabricante NewFabricante)
        {
            try
            {
                var FabricanteRes = _context.Fabricantes.Add(NewFabricante);
                _context.SaveChanges();
                return Int32.Parse(FabricanteRes.Entity.IdFabricante.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateFabricante(Fabricante editFabricante)
        {
            try
            {
                _context.Fabricantes.Update(editFabricante);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
