using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMaquinaProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataMaquinaProceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<MaquinaProceso> findAllMaquinasProceso(){
            return _context.MaquinaProcesos.ToList();   
        }

        public MaquinaProceso FindMaquinaProcesoByID(long MaquinaProceso)
        {
            return _context.MaquinaProcesos.AsNoTracking().SingleOrDefault(us => us.IdMaquinaProceso == MaquinaProceso);
        }

        public List<ResponseMaquinaProceso> FindMaquinaProceso(long Maquina)
        {

            var originalList = _context.MaquinaProcesos.Where(us => us.MaquinaIdMaquina == Maquina).ToList();

            var query = from pop in _context.MaquinaProcesos.Where(us => us.MaquinaIdMaquina == Maquina)
                        join o in _context.Set<Proceso>()
                            on pop.ProcesoIdProceso equals o.IdProceso
                        select new ResponseMaquinaProceso { IdMaquinaProceso = pop.IdMaquinaProceso, MaquinaIdMaquina = pop.MaquinaIdMaquina, ProcesoIdProceso = o.IdProceso, Codigo = o.Codigo, Nombre = o.Nombre, Descripcion = o.Descripcion, Activo = pop.Activo };

            List<ResponseMaquinaProceso> res = query.ToList();

            //foreach (MaquinaProceso elemento in originalList)
            //{
            //    Proceso proc = _context.Procesos.AsNoTracking().SingleOrDefault(us => us.IdProceso == elemento.ProcesoIdProceso);
            //    elemento.ProcesoIdProcesoNavigation = proc;
            //}

            //var result = originalList.Select((maquinaProc, i) =>

            //       new ResponseMaquinaProceso
            //       {
            //           IdMaquinaProceso = maquinaProc.IdMaquinaProceso,
            //           MaquinaIdMaquina = maquinaProc.MaquinaIdMaquina,
            //           ProcesoIdProceso = maquinaProc.ProcesoIdProceso,
            //           Activo = (bool)maquinaProc.Activo,
            //           Proceso = new RequestProceso
            //           {
            //               IdProceso = maquinaProc.ProcesoIdProcesoNavigation.IdProceso,
            //               Codigo = maquinaProc.ProcesoIdProcesoNavigation.Codigo,
            //               Nombre = maquinaProc.ProcesoIdProcesoNavigation.Nombre,
            //               Descripcion = maquinaProc.ProcesoIdProcesoNavigation.Descripcion,
            //               Activo = (bool)maquinaProc.ProcesoIdProcesoNavigation.Activo
            //           }
            //       }).ToList();
            //return result;
            return res;
        }


        public long AddMaquinaProceso(MaquinaProceso item, string ip)
        {
            try
            {
                var MaquinaProcesoRes = _context.MaquinaProcesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(MaquinaProcesoRes.Entity.MaquinaIdMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateMaquinaProceso(MaquinaProceso item, string ip)
        {
            try
            {
                _context.MaquinaProcesos.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

    }
}
