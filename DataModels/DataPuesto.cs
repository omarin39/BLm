using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPuesto
    {
        private readonly Carta_vContext _context;

        public DataPuesto()
        {
            _context = new Carta_vContext();
        }

        public async Task<List<Puesto>> FindAllPuestos()
        {

            return await _context.Puestos.ToListAsync();
        }
        public Puesto FindPuesto(int tipoBusqueda, long id_puestoExterno, string nombrePuesto)
        {
            Puesto resultadobusqueda = new();
            switch (tipoBusqueda)
            {
                case 1:
                    resultadobusqueda = _context.Puestos.SingleOrDefault(us => us.IdPuestoExt == id_puestoExterno);
                    break;
                case 2:
                    resultadobusqueda = _context.Puestos.SingleOrDefault(us => us.DescPuesto == nombrePuesto);
                    break;
                default:
                    break;
            }
            return resultadobusqueda;
        }

        public long AddPuesto(Puesto NewPuesto)
        {
            try
            {
                var puestoRes = _context.Puestos.Add(NewPuesto);
                _context.SaveChanges();
                return Int32.Parse(puestoRes.Entity.IdPuesto.ToString());
            }
            catch (Exception ex  )
            {
                var r = ex.Message;
                return 0; ;
            }
        }

        public long UpdatePuesto()//(long id_puestoExterno, string nombrePuesto)
        {
            try
            {
                //_context.Puestos.Update(editPuesto);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0; ;
            }
        }
    }
}
