using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataFirmasExamenCertificacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataFirmasExamenCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public long AddFirmasExamenCertificacion(FirmasExamenCertificacion item, string ip)
        {
            try
            {
                var FirmasExamenCertificacionRes = _context.FirmasExamenCertificacions.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(FirmasExamenCertificacionRes.Entity.IdFirmaExamen.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public List<ResponseFirmasPendientesExamenCertifica> FindFirmasPendientes()
        {
            var query = from ExamC in _context.ExamenDeCertificacions.AsNoTracking().Where(us => us.Activo == true && us.Concluido == false)
                        join ce in _context.Set<CapacitacionEmpleado>().AsNoTracking().Where(us => us.Activo == true && us.Concluida == true)
                            on new { A = ExamC.IdCapacitacionEmpleado }
                            equals new { A = ce.IdCapacitacion}
                        join o in _context.Set<Empleado>().AsNoTracking().Where(us => us.Activo == true)
                            on new { A = ce.IdEmpleado }
                            equals new { A = o.IdEmpleado }
                        join niv in _context.Set<NivelCertificacion>().AsNoTracking()
                            on new { A = ce.IdNivelCertificacion }
                        equals new { A = niv.IdNivelCertificacion }
                        join pro in _context.Set<Proceso>().AsNoTracking()
                        on new { A = ce.IdProceso }
                        equals new { A = pro.IdProceso }
                        select new ResponseFirmasPendientesExamenCertifica {IdExamenCertificacion = ExamC.IdExamenCertificacion, IdCapacitacionEmpleado = ExamC.IdCapacitacionEmpleado,TotalFinalExamen = ExamC.TotalFinalExamen,EstadoExamen = ExamC.EstadoExamen,NominaEmpleado = int.Parse(o.NumeroNomina),IdEmpleado = ce.IdEmpleado, Pieza = ce.Pieza, IdProceso = ce.IdProceso,Maquina = ce.Maquina,IdNivelCertificacion = ce.IdNivelCertificacion,Concluido = ExamC.Concluido, Activo = ExamC.Activo, NombreEmpleado = o.Nombre + " " + o.ApellidoPaterno + " " + o.ApellidoMaterno, NombreNivel = niv.NombreNivelCertificacion, NombreProceso = pro.Codigo + " - " + pro.Nombre};
        List<ResponseFirmasPendientesExamenCertifica> res = query.ToList();
            return res;
        }

    }
}
