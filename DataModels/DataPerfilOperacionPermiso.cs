using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataPerfilOperacionPermiso
    {
        private readonly Carta_vContext _context;

        public DataPerfilOperacionPermiso()
        {
            _context = new Carta_vContext();
        }

        public  List<PerfilOperacionPermiso> FindAllPerfilOperacionPermiso()
        {
            return  _context.PerfilOperacionPermisos.ToList();
        }
        public PerfilOperacionPermiso FindPerfilOperacionPermiso(long idPerfilOperacionPermiso)
        {
            return _context.PerfilOperacionPermisos.AsNoTracking().SingleOrDefault(us => us.Id == idPerfilOperacionPermiso);
        }

        public long AddPerfilOperacionPermiso(PerfilOperacionPermiso NewPerfilOperacionPermiso)
        {
            try
            {
                var PerfilOperacionPermisoRes = _context.PerfilOperacionPermisos.Add(NewPerfilOperacionPermiso);
                _context.SaveChanges();
                return Int32.Parse(PerfilOperacionPermisoRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePerfilOperacionPermiso(PerfilOperacionPermiso editPerfilOperacionPermiso)
        {
            try
            {
                _context.PerfilOperacionPermisos.Update(editPerfilOperacionPermiso);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
