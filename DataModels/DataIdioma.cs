using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataIdioma
    {
        private readonly Carta_vContext _context;

        public DataIdioma()
        {
            _context = new Carta_vContext();
        }

        public List<Idioma> FindAllIdioma()
        {
            return _context.Idiomas.ToList();
        }
        public Idioma FindIdioma(long idIdioma)
        {
            return _context.Idiomas.AsNoTracking().SingleOrDefault(us => us.IdIdioma == idIdioma);
        }

        public long AddIdioma(Idioma NewIdioma)
        {
            try
            {
                var idiomaRes = _context.Idiomas.Add(NewIdioma);
                _context.SaveChanges();
                return Int32.Parse(idiomaRes.Entity.IdIdioma.ToString());
            }
            catch (Exception ex)
            {

                //var r = ex.InnerException.Message;
                //return 0;
                throw new Exception(ex.InnerException.Message);
            }
        }

        public int UpdateIdioma(Idioma editIdioma)
        {
            try
            {
                //_context.Empleados.Update(editEmpleado);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
