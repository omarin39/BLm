using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataProceso
    {
        private readonly Carta_vContext _context;

        public DataProceso()
        {
            _context = new Carta_vContext();
        }

        public List<Proceso> FindAllProcesos()
        {
            return  _context.Procesos.ToList();
        }
        public Proceso FindProceso(string Proceso)
        {
            return _context.Procesos.AsNoTracking().SingleOrDefault(us => us.Nombre == Proceso);
        }

        public long AddProceso(Proceso NewProceso)
        {
            try
            {
                var ProcesoRes = _context.Procesos.Add(NewProceso);
                _context.SaveChanges();
                return Int32.Parse(ProcesoRes.Entity.IdProceso.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateProceso(Proceso _Proceso)
        {
            try
            {
                _context.Procesos.Update(_Proceso);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
