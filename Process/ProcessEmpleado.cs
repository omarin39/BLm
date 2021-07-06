using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;

namespace APIRestV2.Controllers.Process
{
    public class ProcessEmpleado
    {
        public DataEmpleado empleadoData = new();
        public ResponseGral AddEmpleado(RequestEmpleado empleado, String ip)
        {
            ResponseGral respAltaEmpleado = new();
            try
            {
                Empleado logNewRegistro = new();
                logNewRegistro.NumeroNomina = empleado.NumeroNomina;
                logNewRegistro.Nombre = empleado.Nombre;
                logNewRegistro.ApellidoPaterno = empleado.ApellidoMaterno;
                logNewRegistro.ApellidoMaterno = empleado.ApellidoMaterno;
                logNewRegistro.FechaNacimiento = empleado.FechaNacimiento;
                logNewRegistro.FechaIngreso = empleado.FechaIngreso;
                logNewRegistro.Email = empleado.Email;
                logNewRegistro.NominaJefe = empleado.NominaJefe;

                if(empleado.DepartamentoIdDepartamentoNivel0!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel0 = (long)empleado.DepartamentoIdDepartamentoNivel0;
                }

                if(empleado.DepartamentoIdDepartamentoNivel1!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel1 = empleado.DepartamentoIdDepartamentoNivel1;
                }

                 if(empleado.DepartamentoIdDepartamentoNivel2!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel2 = empleado.DepartamentoIdDepartamentoNivel2;
                }

                 if(empleado.DepartamentoIdDepartamentoNivel3!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel3 = empleado.DepartamentoIdDepartamentoNivel3;
                }

                logNewRegistro.IdiomaIdIdioma = empleado.IdiomaIdIdioma;
                logNewRegistro.PuestoIdPuesto = empleado.PuestoIdPuesto;
                logNewRegistro.UnidadNegocioIdUnidadNegocio = empleado.UnidadNegocioIdUnidadNegocio;
                logNewRegistro.CentroCostoIdCentroCosto = empleado.CentroCostoIdCentroCosto;
                logNewRegistro.IdPerfil = empleado.IdPerfil;
                long respNewUSR = empleadoData.AddEmpleado(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaEmpleado.Id = respNewUSR;
                    respAltaEmpleado.Codigo = "200";
                    respAltaEmpleado.Mensaje = "OK";
                    return respAltaEmpleado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ResponseGral UpdateEmpleado( RequestEmpleado empleado, String ip)
        {
            ResponseGral respAltaEmpleado = new();
            var empleadoBuscado = FindEmpleado(empleado.IdEmpleado);
            if(empleadoBuscado==null){
                 return respAltaEmpleado;
            }
            else if (empleadoBuscado.IdEmpleado == -1)
            {
                respAltaEmpleado.Id = empleado.IdEmpleado;
                respAltaEmpleado.Codigo = "400";
                respAltaEmpleado.Mensaje = "Not found";
                return respAltaEmpleado;
            }
            else
            {
                try
                {
                    empleadoBuscado.NumeroNomina = empleado.NumeroNomina;
                    empleadoBuscado.Nombre = empleado.Nombre;
                    empleadoBuscado.ApellidoPaterno = empleado.ApellidoPaterno;
                    empleadoBuscado.ApellidoMaterno = empleado.ApellidoMaterno;
                    empleadoBuscado.FechaNacimiento = empleado.FechaNacimiento;
                    empleadoBuscado.FechaIngreso = empleado.FechaIngreso;
                    empleadoBuscado.Email = empleado.Email;
                    empleadoBuscado.NominaJefe = empleado.NumeroNomina;
                    //empleadoBuscado.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;
                    empleadoBuscado.DepartamentoIdDepartamentoNivel1 = empleado.DepartamentoIdDepartamentoNivel1;
                    empleadoBuscado.DepartamentoIdDepartamentoNivel2 = empleado.DepartamentoIdDepartamentoNivel2;
                    empleadoBuscado.DepartamentoIdDepartamentoNivel3 = empleado.DepartamentoIdDepartamentoNivel3;
                    empleadoBuscado.IdiomaIdIdioma = empleado.IdiomaIdIdioma;
                    empleadoBuscado.PuestoIdPuesto = empleado.PuestoIdPuesto;
                    empleadoBuscado.UnidadNegocioIdUnidadNegocio = empleado.UnidadNegocioIdUnidadNegocio;
                    empleadoBuscado.CentroCostoIdCentroCosto = empleado.CentroCostoIdCentroCosto;
                    empleadoBuscado.CuentaUsuario = empleado.CuentaUsuario;
                    empleadoBuscado.IdPerfil = empleado.IdPerfil;
                    var respNewEmpleado = empleadoData.UpdateEmpleado(empleadoBuscado,ip);
                    if (respNewEmpleado > 0)
                    {
                        respAltaEmpleado.Id = empleadoBuscado.IdEmpleado;
                        respAltaEmpleado.Codigo = "200";
                        respAltaEmpleado.Mensaje = "OK";
                        return respAltaEmpleado;
                    }
                    else
                    {
                        respAltaEmpleado.Id = empleadoBuscado.IdEmpleado;
                        respAltaEmpleado.Codigo = "400";
                        respAltaEmpleado.Mensaje = "Record not found";
                        return respAltaEmpleado;
                    }
                }
                catch (Exception ex)
                {
                    respAltaEmpleado.Id = empleadoBuscado.IdEmpleado;
                    respAltaEmpleado.Codigo = "400";
                    respAltaEmpleado.Mensaje =ex.InnerException.Message;
                    return respAltaEmpleado;
                }
            }
        }
        public Empleado FindEmpleado(long idEmpleado){
            Empleado RespAltaEmpleado = empleadoData.FindEmpleado(idEmpleado);
            if(RespAltaEmpleado==null){
                RespAltaEmpleado = new Empleado();
                RespAltaEmpleado.IdEmpleado = -1;
            }
            return RespAltaEmpleado;
        }

        public Empleado FinEmpleadoCertifica(long IdEmpleado)
        {
            return empleadoData.FinEmpleadoCertifica(IdEmpleado);
        }


        public List<Empleado> FindAllEmpleado()
        {
            List<Empleado> ResEmpleadoRet = empleadoData.FindAllEmpleado();
            return ResEmpleadoRet;
        }

        public List<Empleado> FindAllEmpleadosPorPlanta(long IdPlanta)
        {
            List<Empleado> ResEmpleadoRet = empleadoData.FindAllEmpleadosPorPlanta(IdPlanta);
            return ResEmpleadoRet;
        }

        

        public List<Empleado> FindAllEmpleadoActivos()
        {
            List<Empleado> ResEmpleadoRet = empleadoData.FindAllEmpleadoActivos();
            return ResEmpleadoRet;
        }


        public List<Empleado> FindAllEmpleadosPorPerfil(long idPerfil)
        {
            List<Empleado> ResEmpleadoRet = empleadoData.FindAllEmpleadosPorPerfil(idPerfil);
            return ResEmpleadoRet;
        }

        public ResponseEmpleado FindEmpleadoPorCuenta(string CuentaUsuario)
        {
            ResponseEmpleado EmpleadoCuentaREt = new();
            Empleado ResEmpleadoCuenta = empleadoData.FindEmpleadoPorCuenta(CuentaUsuario);

            DataPerfil PerfilNombre = new();
            var PerfiFinal = PerfilNombre.FindPerfil((long)ResEmpleadoCuenta.IdPerfil);
            DataPerfilOperacionPermiso PermisoB = new();
            var respermiso = PermisoB.FindPerfilOperacionPermisoJoined((long)ResEmpleadoCuenta.IdPerfil);
            EmpleadoCuentaREt.IdPerfil = PerfiFinal.Id;
            EmpleadoCuentaREt.NombrePerfil = PerfiFinal.Perfil1;
            EmpleadoCuentaREt.Permisos = respermiso;
            return EmpleadoCuentaREt;
        }

    }
}
