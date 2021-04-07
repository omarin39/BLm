using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessEmpleado
    {
        private ResponseEmpleado ResponseWS = new();
       
        public DataEmpleado empleadoData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseEmpleado AddEmpleado(RequestEmpleado empleado)
        {
            ResponseEmpleado respAltaEmpleado = new();
            try
            {
                

                Empleado logNewRegistro = new();
                logNewRegistro.NNomina = empleado.NNomina;
                logNewRegistro.Nombre = empleado.Nombre;
                logNewRegistro.ApellidoPaterno = empleado.ApellidoMaterno;
                logNewRegistro.ApellidoMaterno = empleado.ApellidoMaterno;
                logNewRegistro.FNacimiento = empleado.FNacimiento;
                logNewRegistro.FIngreso = empleado.FIngreso;
                logNewRegistro.Email = empleado.Email;
                logNewRegistro.NominaJefe = empleado.NominaJefe;
                //logNewRegistro.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;

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
               
               // logNewRegistro.DepartamentoIdDepartamentoNivel2 = empleado.Departamento_id_departamento_nivel2;
                //logNewRegistro.DepartamentoIdDepartamentoNivel3 = empleado.Departamento_id_departamento_nivel3;
                logNewRegistro.IdiomaIdIdioma = empleado.IdiomaIdIdioma;
                logNewRegistro.PuestosIdPuesto = empleado.PuestosIdPuesto;
                logNewRegistro.UnidadNegocioIdUnidadNegocio = empleado.UnidadNegocioIdUnidadNegocio;
                logNewRegistro.CentroCostoIdCentroCosto = empleado.CentroCostoIdCentroCosto;
                logNewRegistro.IdPerfil = empleado.IdPerfil;


                

                long respNewUSR = empleadoData.AddEmpleado(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaEmpleado.Id = respNewUSR.ToString();
                    respAltaEmpleado.Codigo = "200";
                    
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

        public ResponseEmpleado UpdateEmpleado( RequestEmpleado empleado)
        {
            ResponseEmpleado respAltaEmpleado = new();
            Perfile updAltaEmpleado = new();

            var empleadoBuscado = FindEmpleado(empleado.IdEmpleado);
            if(empleadoBuscado==null){
                 return respAltaEmpleado;
            }else{
                try
                    {

                        empleadoBuscado.NNomina = empleado.NNomina;
                        empleadoBuscado.Nombre = empleado.Nombre;
                        empleadoBuscado.ApellidoPaterno = empleado.ApellidoPaterno;
                        empleadoBuscado.ApellidoMaterno = empleado.ApellidoMaterno;
                        empleadoBuscado.FNacimiento = empleado.FNacimiento;
                        empleadoBuscado.FIngreso = empleado.FIngreso;
                        empleadoBuscado.Email = empleado.Email;
                        empleadoBuscado.NominaJefe = empleado.NNomina;
                        //empleadoBuscado.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel1 = empleado.DepartamentoIdDepartamentoNivel1;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel2 = empleado.DepartamentoIdDepartamentoNivel2;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel3 = empleado.DepartamentoIdDepartamentoNivel3;
                        empleadoBuscado.IdiomaIdIdioma = empleado.IdiomaIdIdioma;
                        empleadoBuscado.PuestosIdPuesto = empleado.PuestosIdPuesto;
                        empleadoBuscado.UnidadNegocioIdUnidadNegocio = empleado.UnidadNegocioIdUnidadNegocio;
                        empleadoBuscado.CentroCostoIdCentroCosto = empleado.CentroCostoIdCentroCosto;
                        empleadoBuscado.IdPerfil = empleado.IdPerfil;
                      


                        var respNewEmpleado = empleadoData.UpdateEmpleado(empleadoBuscado);
                        if (respNewEmpleado > 0)
                        {
                            respAltaEmpleado.Id = empleadoBuscado.IdEmpleado.ToString();
                            respAltaEmpleado.Codigo = "200";
                        
                            return respAltaEmpleado;

                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
            }

            
        }

        public Empleado FindEmpleado(long idEmpleado){

            Empleado respAltaEmpleado = new();

            respAltaEmpleado = empleadoData.FindEmpleado(idEmpleado);
            if(respAltaEmpleado==null){
                respAltaEmpleado.IdEmpleado = -1;
            }
          
              return respAltaEmpleado;
        }

         public List<Empleado> FindAllEmpleado(){
            List<Empleado> resEmpleadoRet = new List<Empleado>();
            resEmpleadoRet =  empleadoData.FindAllEmpleado();
           
            return resEmpleadoRet;
        }

       


    }
}
