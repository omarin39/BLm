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
                logNewRegistro.NNomina = empleado.n_nomina;
                logNewRegistro.Nombre = empleado.nombre;
                logNewRegistro.ApellidoPaterno = empleado.apellido_paterno;
                logNewRegistro.ApellidoMaterno = empleado.apellido_materno;
                logNewRegistro.FNacimiento = empleado.f_nacimiento;
                logNewRegistro.FIngreso = empleado.f_ingreso;
                logNewRegistro.Email = empleado.email;
                logNewRegistro.NominaJefe = empleado.nomina_jefe;
                //logNewRegistro.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;

                if(empleado.Departamento_id_departamento_nivel0!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;
                }

                if(empleado.Departamento_id_departamento_nivel1!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel1 = empleado.Departamento_id_departamento_nivel1;
                }

                 if(empleado.Departamento_id_departamento_nivel2!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel2 = empleado.Departamento_id_departamento_nivel2;
                }

                 if(empleado.Departamento_id_departamento_nivel3!=null){
                  logNewRegistro.DepartamentoIdDepartamentoNivel3 = empleado.Departamento_id_departamento_nivel3;
                }
               
               // logNewRegistro.DepartamentoIdDepartamentoNivel2 = empleado.Departamento_id_departamento_nivel2;
                //logNewRegistro.DepartamentoIdDepartamentoNivel3 = empleado.Departamento_id_departamento_nivel3;
                logNewRegistro.IdiomaIdIdioma = empleado.idioma_id_idioma;
                logNewRegistro.PuestosIdPuesto = empleado.Puestos_id_puesto;
                logNewRegistro.UnidadNegocioIdUnidadNegocio = empleado.Unidad_negocio_id_unidad_negocio;
                logNewRegistro.CentroCostoIdCentroCosto = empleado.Centro_costo_id_centro_costo;
                logNewRegistro.IdPerfil = empleado.id_Perfil;


                

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

            var empleadoBuscado = FindEmpleado(empleado.id_empleado);
            if(empleadoBuscado==null){
                 return respAltaEmpleado;
            }else{
                try
                    {

                        empleadoBuscado.NNomina = empleado.n_nomina;
                        empleadoBuscado.Nombre = empleado.nombre;
                        empleadoBuscado.ApellidoPaterno = empleado.apellido_paterno;
                        empleadoBuscado.ApellidoMaterno = empleado.apellido_materno;
                        empleadoBuscado.FNacimiento = empleado.f_nacimiento;
                        empleadoBuscado.FIngreso = empleado.f_ingreso;
                        empleadoBuscado.Email = empleado.email;
                        empleadoBuscado.NominaJefe = empleado.nomina_jefe;
                        //empleadoBuscado.DepartamentoIdDepartamentoNivel0 = empleado.Departamento_id_departamento_nivel0;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel1 = empleado.Departamento_id_departamento_nivel1;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel2 = empleado.Departamento_id_departamento_nivel2;
                        empleadoBuscado.DepartamentoIdDepartamentoNivel3 = empleado.Departamento_id_departamento_nivel3;
                        empleadoBuscado.IdiomaIdIdioma = empleado.idioma_id_idioma;
                        empleadoBuscado.PuestosIdPuesto = empleado.Puestos_id_puesto;
                        empleadoBuscado.UnidadNegocioIdUnidadNegocio = empleado.Unidad_negocio_id_unidad_negocio;
                        empleadoBuscado.CentroCostoIdCentroCosto = empleado.Centro_costo_id_centro_costo;
                        empleadoBuscado.IdPerfil = empleado.id_Perfil;
                      


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
