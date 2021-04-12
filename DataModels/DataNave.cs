using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataNave
    {
        private readonly Carta_vContext _context;

        public DataNave()
        {
            _context = new Carta_vContext();
        }

        public List<Nafe> FindAllNaves()
        {
            return  _context.Naves.ToList();
        }
        public Nafe FindNave(string Nave)
        {
            return _context.Naves.AsNoTracking().SingleOrDefault(us => us.Nombre == Nave);
        }

        public long AddNave(Nafe NewNave)
        {
            try
            {
                var NaveRes = _context.Naves.Add(NewNave);
                _context.SaveChanges();
                return Int32.Parse(NaveRes.Entity.IdNave.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateNave(Nafe _Nave)
        {
            try
            {
                _context.Naves.Update(_Nave);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
