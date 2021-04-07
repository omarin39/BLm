using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataOperacion
    {
        private readonly Carta_vContext _context;

        public DataOperacion()
        {
            _context = new Carta_vContext();
        }

        public  List<Operacione> FindAllOperacion()
        {
            return  _context.Operaciones.ToList();
        }
        public Operacione FindOperacion(long idOperacion)
        {
            return _context.Operaciones.AsNoTracking().SingleOrDefault(us => us.Id == idOperacion);
        }

        public long AddOperacion(Operacione NewOperacion)
        {
            try
            {
                var OperacionRes = _context.Operaciones.Add(NewOperacion);
                _context.SaveChanges();
                return Int32.Parse(OperacionRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateOperacion(Operacione editOperacion)
        {
            try
            {
                _context.Operaciones.Update(editOperacion);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
