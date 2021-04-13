using APIRest.Models;
using APIRest.Models.Response;
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

        public List<ResponsePerfilOperacionPermisoJoined> FindPerfilOperacionPermisoJoined(long idPerfil)
        {
            var query = from pop in _context.Set<PerfilOperacionPermiso>().Where(pop => pop.IdPerfil == idPerfil)
                        join o in _context.Set<Operacione>()
                            on pop.IdOperacion equals o.Id
                        select new ResponsePerfilOperacionPermisoJoined { Id=pop.Id,IdOperacion=pop.IdOperacion, Operacion=o.Operacion, Crear=pop.Crear,Editar=pop.Editar,Eliminar=pop.Eliminar,Ver= (bool)pop.Ver  };

            List<ResponsePerfilOperacionPermisoJoined> res = query.ToList();

            return res;
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
