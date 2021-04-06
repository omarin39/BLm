using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPerfil
    {
        private readonly Carta_vContext _context;

        public DataPerfil()
        {
            _context = new Carta_vContext();
        }

        public  List<Perfile> FindAllPerfil()
        {
            return  _context.Perfiles.ToList();
        }
        public Perfile FindPerfil(long idPerfil)
        {
            return _context.Perfiles.AsNoTracking().SingleOrDefault(us => us.Id == idPerfil);
        }

        public long AddPerfil(Perfile NewPerfil)
        {
            try
            {
                var perfilRes = _context.Perfiles.Add(NewPerfil);
                _context.SaveChanges();
                return Int32.Parse(perfilRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePerfil(Perfile editPerfil)
        {
            try
            {
                _context.Perfiles.Update(editPerfil);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
