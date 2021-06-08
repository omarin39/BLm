using APIRestV2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using APIRestV2.Models.Response;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataProcesoPiezaMaquina
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataProcesoPiezaMaquina()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<ResponseProcesoPiezaMaquina> findAllProcesoPiezaMaquina()
        {
            var query = from pop in _context.ProcesoPiezaMaquinas
                        join ma in _context.Set<MaquinaProceso>()
                        on new { A = pop.MaquinaProcesoIdMaquinaProceso}
                        equals new { A = ma.IdMaquinaProceso }
                        select new ResponseProcesoPiezaMaquina { IdProcesoPiezaMaquina = pop.IdProcesoPiezaMaquina, PiezaIdPieza = pop.PiezaIdPieza, MaquinaProcesoIdMaquinaProceso = pop.MaquinaProcesoIdMaquinaProceso, UsaPreguntaEstandar = pop.UsaPreguntaEstandar, Activo = pop.Activo, ProcesoIdProceso = ma.ProcesoIdProceso, MaquinaIdMaquina = ma.MaquinaIdMaquina};
            List<ResponseProcesoPiezaMaquina> res = query.ToList();
            return res;
        }

        public ProcesoPiezaMaquina findProcesoPiezaMaquinaIdProcesoPieza(long id)
        {
            return _context.ProcesoPiezaMaquinas.AsNoTracking().SingleOrDefault(us => us.IdProcesoPiezaMaquina == id);
        }

        public List<ResponseProcesoPiezaMaquina> findProcesoPiezaMaquinaIdMaquinaProceso(long id)
        {
            var query = from pop in _context.ProcesoPiezaMaquinas.Where(us => us.MaquinaProcesoIdMaquinaProceso == id).Include("PreguntaPiezas")
                        join o in _context.Set<VwPiezasMultimedia>()
                            on pop.PiezaIdPieza equals o.IdPieza
                        select new ResponseProcesoPiezaMaquina { IdProcesoPiezaMaquina = pop.IdProcesoPiezaMaquina, PiezaIdPieza = pop.PiezaIdPieza, MaquinaProcesoIdMaquinaProceso = pop.MaquinaProcesoIdMaquinaProceso, UsaPreguntaEstandar = pop.UsaPreguntaEstandar, Activo = pop.Activo, NumeroParte = o.NumeroParte, Nombre = o.Nombre, CountPreguntas = pop.PreguntaPiezas.Count(), CountDoc = o.CountDoc, CountVideo = o.CountVideo };
            List<ResponseProcesoPiezaMaquina> res = query.ToList();
            return res;
        }

        public long AddProcesoPiezaMaquina(ProcesoPiezaMaquina item, string ip)
        {
            try
            {
                var ProcesoPiezaRes = _context.ProcesoPiezaMaquinas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(ProcesoPiezaRes.Entity.IdProcesoPiezaMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateProcesoPiezaMaquina(ProcesoPiezaMaquina item, string ip)
        {
            try
            {
                _context.ProcesoPiezaMaquinas.Update(item);
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
