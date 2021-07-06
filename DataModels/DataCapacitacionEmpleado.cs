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
    public class DataCapacitacionEmpleado
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataCapacitacionEmpleado()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<CapacitacionEmpleado> FindAllCapacitacionEmpleado()
        {
            return  _context.CapacitacionEmpleados.ToList();
        }
        public CapacitacionEmpleado FindProceso(long idEmpleado)
        {
            return _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(us => us.IdEmpleado == idEmpleado);
        }

        public CapacitacionEmpleado FindCapacitacionEmpleadoById(long idEmpleado)
        {
            return _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(us => us.IdCapacitacion == idEmpleado);
        }

        /*public bool ValidaClaveExistente(RequestCapacitacionEmpleado inputItem)
        {
            //true si existe
            //false si no existe
           var busqueda = _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(us => us.IdEmpleado .Trim().ToUpper() == Proceso.Codigo.Trim().ToUpper() && us.IdProceso != Proceso.IdProceso);
            return busqueda==null ? false : true;
        }*/

        public long Addentity(CapacitacionEmpleado item,string ip)
        {
            try
            {
                var objRes = _context.CapacitacionEmpleados.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(objRes.Entity.IdCapacitacion.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateCpacitacionEmpleado(CapacitacionEmpleado item,string ip)
        {
            try
            {
                _context.CapacitacionEmpleados.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }

        public List<ResponseCapacitacionEmpleado> FindAllEmpleadoConCapacitacion()
        {
            var query = from pop in _context.CapacitacionEmpleados.AsNoTracking().Where(us => us.Activo == true && us.Concluida == false)
                        join o in _context.Set<Empleado>().AsNoTracking().Where(us => us.Activo == true)
                            on new { A = pop.IdEmpleado }
                            equals new { A = o.IdEmpleado }
                        join niv in _context.Set<NivelCertificacion>().AsNoTracking()
                            on new { A = pop.IdNivelCertificacion }
                        equals new { A = niv.IdNivelCertificacion }
                        join pro in _context.Set<Proceso>().AsNoTracking()
                            on new { A = pop.IdProceso }
                            equals new { A = pro.IdProceso }
                        select new ResponseCapacitacionEmpleado { IdCapacitacion = pop.IdCapacitacion, IdEmpleado = pop.IdEmpleado, Pieza = pop.Pieza, Maquina = pop.Maquina, FechaInicio = pop.FechaInicio, FechaFin = pop.FechaFin, Turno = pop.Turno, Concluida = pop.Concluida, Activo = pop.Activo, NombreEmpleado = o.Nombre+ " " +o.ApellidoPaterno+ " " +o.ApellidoMaterno, NombreNivel = niv.NombreNivelCertificacion, NombreProceso = pro.Codigo+ " - "+ pro.Nombre, IdMentor = pop.IdMentor, IdNivelCertificacion = pop.IdNivelCertificacion, IdProceso = pop.IdProceso, NominaEmpleado = int.Parse(o.NumeroNomina)};

            //List<ExamenDeCertificacion> queryCEM = _context.ExamenDeCertificacions.Where(us => us.Activo == true).ToList();


            //var query1 = from emp in query
            //             where (queryCEM.Any(u => u.IdCapacitacionEmpleado != emp.IdCapacitacion))
            //             select emp;
            //return query1.ToList();
            List<ResponseCapacitacionEmpleado> res = query.ToList();
            return res;
        }

        public List<Empleado> FindAllEmpleadoSinCapacitacion()
        {
            
            List<Empleado> emp1 = _context.Empleados.Where(us => us.Activo == true).ToList();
            List<CapacitacionEmpleado> query = _context.CapacitacionEmpleados.Where(us => us.Activo == true && us.Concluida == false).ToList();


            //var query = from emp in _context.Empleados.Where(us => us.Activo == true)
            //              join o in _context.Set<CapacitacionEmpleado>().Where(us => us.Activo == true && us.Concluida == false)
            //               on emp.IdEmpleado equals o.IdEmpleado
            //              select new Empleado
            //              {
            //                  IdEmpleado = emp.IdEmpleado,
            //                  NumeroNomina = emp.NumeroNomina,
            //                  CuentaUsuario = emp.CuentaUsuario,
            //                  Nombre = emp.Nombre,
            //                  ApellidoPaterno = emp.ApellidoPaterno,
            //                  ApellidoMaterno = emp.ApellidoMaterno,
            //                  FechaNacimiento = emp.FechaNacimiento,
            //                  FechaIngreso = emp.FechaIngreso,
            //                  Email = emp.Email,
            //                  NominaJefe = emp.NominaJefe,
            //                  DepartamentoIdDepartamentoNivel0 = emp.DepartamentoIdDepartamentoNivel0,
            //                  DepartamentoIdDepartamentoNivel1 = emp.DepartamentoIdDepartamentoNivel1,
            //                  DepartamentoIdDepartamentoNivel2 = emp.DepartamentoIdDepartamentoNivel2,
            //                  DepartamentoIdDepartamentoNivel3 = emp.DepartamentoIdDepartamentoNivel3,
            //                  IdiomaIdIdioma = emp.IdiomaIdIdioma,
            //                  PuestoIdPuesto = emp.PuestoIdPuesto,
            //                  UnidadNegocioIdUnidadNegocio = emp.UnidadNegocioIdUnidadNegocio,
            //                  CentroCostoIdCentroCosto = emp.CentroCostoIdCentroCosto,
            //                  Activo = emp.Activo,
            //                  IdPerfil = emp.IdPerfil
            //              };


            var query1 = from emp in emp1
                         where !(query.Any(u => u.IdEmpleado == emp.IdEmpleado)) 
                         select emp;
            return query1.ToList();


        }

        public CapacitacionEmpleado FindIdCapacitacion(long IdCapacitacion)
        {
            return _context.CapacitacionEmpleados.AsNoTracking().SingleOrDefault(ec => ec.IdCapacitacion == IdCapacitacion);
        }


    }
}
