using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataCertificacion
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataCertificacion()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Certificacion> FindAllCertificacions()
        {
            return  _context.Certificacions.AsNoTracking().ToList();
        }
        public Certificacion FindCertificacion(long idCertificacion)
        {
            return _context.Certificacions.AsNoTracking().SingleOrDefault(us => us.IdCertificacion == idCertificacion);
        }

        public List<ResponseCertificacionEmpleado> FindCertificacionByIdEmpleado(long IdEmpleado)
        {
            var query = from pop in _context.CapacitacionEmpleados.AsNoTracking().Where(us => us.Activo == true && us.Concluida == true && us.IdEmpleado == IdEmpleado)
                        join o in _context.Set<Empleado>().AsNoTracking().Where(us => us.Activo == true)
                            on new { A = pop.IdEmpleado }
                            equals new { A = o.IdEmpleado }
                        join niv in _context.Set<NivelCertificacion>().AsNoTracking()
                            on new { A = pop.IdNivelCertificacion }
                        equals new { A = niv.IdNivelCertificacion }
                        join pro in _context.Set<Proceso>().AsNoTracking()
                            on new { A = pop.IdProceso }
                            equals new { A = pro.IdProceso }
                        join exa in _context.Set<ExamenDeCertificacion>().AsNoTracking()
                            on new { A = pop.IdCapacitacion}
                            equals new { A = exa.IdCapacitacionEmpleado}
                        join cer in _context.Set<Certificacion>().AsNoTracking()
                        on new { A = exa.IdExamenCertificacion }
                        equals new { A = cer.IdExamenDeCertificacion}
                        select new ResponseCertificacionEmpleado
                        {
                            IdCertificacion = cer.IdExamenDeCertificacion,
                            FechaEntrenamiento = cer.FechaEntrenamiento,
                            FechaCertificacion = cer.FechaCertificacion,
                            IdCertificador = cer.IdCertificador,
                            TokenCertificador = cer.TokenCertificador,
                            FechaCertificador = cer.FechaCertificador,
                            IdMentor = cer.IdMentor,
                            TokenMentor = cer.TokenMentor,
                            FechaMentor = cer.FechaMentor,
                            IdResponsable = cer.IdResponsable,
                            TokenResponsable = cer.TokenResponsable,
                            FechaResponsable = cer.FechaResponsable,
                            Resultado = cer.Resultado,
                            IdExamenDeCertificacion = cer.IdExamenDeCertificacion,
                            IdNivelCertificacion = cer.IdNivelCertificacion,
                            Activo = cer.Activo,
                            IdCapacitacion = pop.IdCapacitacion,
                            IdEmpleado = pop.IdEmpleado,
                            Pieza = pop.Pieza,
                            IdProceso = pop.IdProceso,
                            Maquina = pop.Maquina,
                            NombreNivel = niv.NombreNivelCertificacion,
                            NombreProceso = pro.Codigo + " - " + pro.Nombre,
                        };

            //List<ExamenDeCertificacion> queryCEM = _context.ExamenDeCertificacions.Where(us => us.Activo == true).ToList();


            //var query1 = from emp in query
            //             where (queryCEM.Any(u => u.IdCapacitacionEmpleado != emp.IdCapacitacion))
            //             select emp;
            //return query1.ToList();
            List<ResponseCertificacionEmpleado> res = query.ToList();
            return res;
        }

        

        public long AddCertificacion(Certificacion newItem, String ip)
        {
            try
            {
                var CertificacionRes = _context.Certificacions.Add(newItem);
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(CertificacionRes.Entity.IdCertificacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(newItem, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCertificacion(Certificacion item, String ip)
        {
            try
            {
                _context.Certificacions.Update(item);
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
