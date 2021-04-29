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
        private Controllers.Process.Process_Log procLog;
        public DataPerfilOperacionPermiso()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
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

        public long AddPerfilOperacionPermiso(PerfilOperacionPermiso item,string ip)
        {
            try
            {
                var PerfilOperacionPermisoRes = _context.PerfilOperacionPermisos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PerfilOperacionPermisoRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePerfilOperacionPermiso(PerfilOperacionPermiso item,string ip)
        {
            try
            {
                _context.PerfilOperacionPermisos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }
    }
}
