using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPieza
    {
        private readonly Carta_vContext _context;

        public DataPieza()
        {
            _context = new Carta_vContext();
        }

        public List<Pieza> FindAllPiezas()
        {
            return  _context.Piezas.ToList();
        }
        public Pieza FindPieza(string Pieza)
        {
            return _context.Piezas.AsNoTracking().SingleOrDefault(us => us.Nombre == Pieza);
        }

        public long AddPieza(Pieza NewPieza)
        {
            try
            {
                var PiezaRes = _context.Piezas.Add(NewPieza);
                _context.SaveChanges();
                return Int32.Parse(PiezaRes.Entity.IdPieza.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePieza(Pieza _Pieza)
        {
            try
            {
                _context.Piezas.Update(_Pieza);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
