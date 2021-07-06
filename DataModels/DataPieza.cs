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
    public class DataPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<VwPiezasMultimedia> FindAllPiezas()
        {
           
            return _context.VwPiezasMultimedias.AsNoTracking().ToList();
          
        }

        public bool ValidaClaveExistente(RequestPieza _Pieza)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.Piezas.AsNoTracking().SingleOrDefault(us => us.NumeroParte.Trim().ToUpper() == _Pieza.NumeroParte.Trim().ToUpper() && us.IdPieza != _Pieza.IdPieza);
            return busqueda == null ? false : true;
        }

        public Pieza FindPieza(string Pieza)
        {
           
           return _context.Piezas.AsNoTracking().SingleOrDefault(us => us.Nombre == Pieza);
        }
        //public List<Pieza> FindPiezaCertificacion(string IdPieza)
        //{
        //    List<Pieza> PzasCertificacion = new();
        //    if (IdPieza.ToUpper() == "ALL")
        //    {
        //        PzasCertificacion = _context.Piezas.AsNoTracking().ToList();
        //    }
        //    else
        //    {
        //        PzasCertificacion = _context.Piezas.AsNoTracking().Where(pza => pza.IdPieza == long.Parse(IdPieza)).ToList();
        //    }

        //    return PzasCertificacion;
        //}

        public Pieza FindPiezaCertificacion(string IdPieza)
        {
            return _context.Piezas.AsNoTracking().SingleOrDefault(pza => pza.IdPieza == long.Parse(IdPieza));
            
        }

        public List<VwPiezasasignacapacitacion> FindPiezaAsignaCapacitacion(long IdEmp)
        {
            return _context.VwPiezasasignacapacitacions.AsNoTracking().ToList();
            //CapacitacionEmpleado CapEmp = _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(em => em.IdEmpleado == IdEmp && em.Concluida==false);

            //if (CapEmp != null)
            //{
            //    return PzaDb;
            //}
            //else
            //{
            //    List<VwPiezasasignacapacitacion> PzaTemp = new();
            //    foreach (var item in PzaDb)
            //    {
            //        if (item.IdPieza != CapEmp.Pieza)
            //        {

            //        }
            //    }
            //    return PzaDb;
            //}

        }

        public List<VwPiezaprocesoasignacapacitacion> FindProcesosdePiezaAsignaCapacitacion(long IdPieza)
        {
            return _context.VwPiezaprocesoasignacapacitacions.AsNoTracking().Where(PzaProc => PzaProc.IdPieza == IdPieza).ToList();

        }

        public List<VwPiezaprocesomaquinaasignacapacitacion> FindMaquinadeProcesosdePiezaAsignaCapacitacion(long IdProceso)
        {
            return _context.VwPiezaprocesomaquinaasignacapacitacions.AsNoTracking().Where(PzaProcMaquina => PzaProcMaquina.IdProceso == IdProceso).ToList();
        }

        public Pieza FindPiezaToId(long IdPieza)
        {
            return _context.Piezas.AsNoTracking().SingleOrDefault(us => us.IdPieza == IdPieza);
        }


        public VwPiezasMultimedia FindPiezaPorId(long idPieza)
        {
            return _context.VwPiezasMultimedias.AsNoTracking().SingleOrDefault(p => p.IdPieza == idPieza);
            //   return _context.Piezas.AsNoTracking().SingleOrDefault(us => us.Nombre == Pieza);
        }

        public long AddPieza(Pieza item,string ip)
        {
            try
            {
                var PiezaRes = _context.Piezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdPieza.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePieza(Pieza item,string ip)
        {
            try
            {
                _context.Piezas.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        internal List<Pieza> FindPiezaAutoComplete(string param)
        {
            param = param.ToUpper().Replace("%2F", "/").Trim();
            return _context.Piezas.Where(p => p.Nombre.ToUpper().Contains(param) || p.NumeroParte.ToUpper().Contains(param)).Take(200).ToList();
           
        }
    }
}
