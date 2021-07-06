using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using APIRestV2.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessCapacitacionEmpleado
    {       
        public DataCapacitacionEmpleado procesoData = new();
        public ProcessExamenCertificacion ExameCerrtiData = new();
        public ResponseGral AddCapacitacionEmpleado(RequestCapacitacionEmpleado inputEntity, String ip)
        {
            ResponseGral respAltaProceso = new();
            try
            {
                // if ( ProcesoData.ValidaClaveExistente(inputEntity) ==false ) {
                DateTime fechaInicio = inputEntity.FechaInicio;
                int difFecha;
                ProcessConfiguracionNivelesCertificacion Processconfig = new();
                ResponseConfiguracionNivelesCertificacion configBuscar
                    = Processconfig.FindByIdNivelCertifica(inputEntity.IdNivelCertificacion);
                ProcessEmpleado processEmpleado = new();
                Empleado empleadoValidarFecha = processEmpleado.FindEmpleado(inputEntity.IdEmpleado);
                if (configBuscar != null)
                {
                    difFecha = (fechaInicio - empleadoValidarFecha.FechaIngreso).Days;
                    DateTime fechaFin;
                    if (difFecha >= 30)
                    {
                        fechaFin = inputEntity.FechaInicio.AddDays(configBuscar.PlazoCertificaOperAntiguo);
                        inputEntity.FechaFin = fechaFin;
                    }
                    else
                    {
                        fechaFin = inputEntity.FechaInicio.AddDays(configBuscar.PlazoCertificaOperNuevo);
                        inputEntity.FechaFin = fechaFin;
                    }
                }

                CapacitacionEmpleado newObjEntity = new();
                    newObjEntity.IdEmpleado = inputEntity.IdEmpleado;
                    newObjEntity.Pieza = inputEntity.Pieza;
                    newObjEntity.IdProceso= inputEntity.IdProceso;
                    newObjEntity.Maquina = inputEntity.Maquina;
                    newObjEntity.IdNivelCertificacion = inputEntity.IdNivelCertificacion;
                    newObjEntity.IdMentor = inputEntity.IdMentor;
                    newObjEntity.FechaInicio = inputEntity.FechaInicio;
                    newObjEntity.FechaFin = inputEntity.FechaFin;
                    newObjEntity.Turno = inputEntity.Turno;
                    newObjEntity.Concluida = inputEntity.Concluida;
                    newObjEntity.Activo = inputEntity.Activo;

                long respNewEntity = procesoData.Addentity(newObjEntity, ip);
                    if(respNewEntity > 0)
                    {
                        respAltaProceso.Id = respNewEntity;
                        respAltaProceso.Codigo = "200";
                        respAltaProceso.Mensaje = "OK";
                        return respAltaProceso;
                    }
                    else
                    {
                        return null;
                    }
                /*}
                else
                {
                    respAltaProceso.Id = -1;
                    respAltaProceso.Codigo = "-1";
                    respAltaProceso.Mensaje ="Proceso Duplicado";
                    return respAltaProceso;

                }*/
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateCapacitacionEmpleado(RequestCapacitacionEmpleado capEmpleado, String ip)
        {
            ResponseGral respAltaProceso = new();
            var itemBuscado = FindCapacitacionEmpleado(capEmpleado.IdEmpleado);

            if (itemBuscado == null)
            {
                return respAltaProceso;
            }
            else if (itemBuscado.IdProceso == -1)
            {
                respAltaProceso.Id = itemBuscado.IdCapacitacion;
                respAltaProceso.Codigo = "400";
                respAltaProceso.Mensaje = "Record not found";
                return respAltaProceso;
            }
            else
            {
                try
                {
                    /* if (procesoData.ValidaClaveExistente(Proceso) == false)
                     {*/
                    itemBuscado.IdEmpleado = capEmpleado.IdEmpleado;
                    itemBuscado.Pieza = capEmpleado.Pieza;
                    itemBuscado.IdProceso = capEmpleado.IdProceso;
                    itemBuscado.Maquina = capEmpleado.Maquina;
                    itemBuscado.IdNivelCertificacion = capEmpleado.IdNivelCertificacion;
                    itemBuscado.IdMentor = capEmpleado.IdMentor;
                    itemBuscado.FechaInicio = capEmpleado.FechaInicio;
                    itemBuscado.FechaFin = capEmpleado.FechaFin;
                    itemBuscado.Turno = capEmpleado.Turno;
                    itemBuscado.Concluida = capEmpleado.Concluida;
                    itemBuscado.Activo = capEmpleado.Activo;




                    var respNewProceso = procesoData.UpdateCpacitacionEmpleado(itemBuscado, ip);
                        if (respNewProceso > 0)
                        {
                            respAltaProceso.Id = itemBuscado.IdCapacitacion;
                            respAltaProceso.Codigo = "200";
                            respAltaProceso.Mensaje = "OK";
                            return respAltaProceso;
                        }
                        else
                        {
                            respAltaProceso.Id = itemBuscado.IdCapacitacion;
                            respAltaProceso.Codigo = "400";
                            respAltaProceso.Mensaje = "Record not found";
                            return respAltaProceso;
                        }
                   /* }
                    else
                    {
                        respAltaProceso.Id = -1;
                        respAltaProceso.Codigo = "-1";
                        respAltaProceso.Mensaje = "Duplicidad";
                        return respAltaProceso;
                    }*/
                }
                catch (Exception ex)
                {
                    respAltaProceso.Id = itemBuscado.IdCapacitacion;
                    respAltaProceso.Codigo = "400";
                    respAltaProceso.Mensaje = ex.InnerException.Message;
                    return respAltaProceso;
                }
            }
        }

        public CapacitacionEmpleado FindCapacitacionEmpleado(long idEmpleado){
            CapacitacionEmpleado resp = procesoData.FindProceso(idEmpleado);
            if (resp == null)
            {
                resp = new CapacitacionEmpleado();
                resp.IdProceso = -1;
            }
            return resp;
        }

        public CapacitacionEmpleado FindCapacitacionEmpleadoById(long idEmpleado)
        {
            CapacitacionEmpleado resp = procesoData.FindCapacitacionEmpleadoById(idEmpleado);
            if (resp == null)
            {
                resp = new CapacitacionEmpleado();
                resp.IdProceso = -1;
            }
            return resp;
        }

        public List<CapacitacionEmpleado> FindAllCapacitacionEmpleado()
        {
            List<CapacitacionEmpleado> resProcesoRet = procesoData.FindAllCapacitacionEmpleado();
            return resProcesoRet;
        }

        public List<ResponseCapacitacionEmpleado> FindAllEmpleadoConCapacitacion()
        {
            List<ResponseCapacitacionEmpleado> resProcesoRet = procesoData.FindAllEmpleadoConCapacitacion();
            return resProcesoRet;
        }

        public List<Empleado> FindAllEmpleadoSinCapacitacion()
        {
            List<Empleado> resProcesoRet = procesoData.FindAllEmpleadoSinCapacitacion();
            return resProcesoRet;
        }

        public bool AddCapacitacionEmpleadoFirmaExamen(long IdExamenCertificacion, string ip)
        {
            try
            {
                var certexa = ExameCerrtiData.FindOnlyExamenCertificaPorId(IdExamenCertificacion);
                var capacitaempleado = FindCapacitacionEmpleadoById(certexa.IdCapacitacionEmpleado);
                // if ( ProcesoData.ValidaClaveExistente(inputEntity) ==false ) {
                DateTime fechaInicio = DateTime.Now;
                int difFecha;
                ProcessConfiguracionNivelesCertificacion Processconfig = new();
                ResponseConfiguracionNivelesCertificacion configBuscar
                    = Processconfig.FindByIdNivelCertifica(capacitaempleado.IdNivelCertificacion + 1 );
                ProcessEmpleado processEmpleado = new();
                Empleado empleadoValidarFecha = processEmpleado.FindEmpleado(capacitaempleado.IdEmpleado);
                if (configBuscar != null)
                {
                    difFecha = (fechaInicio - empleadoValidarFecha.FechaIngreso).Days;
                    DateTime fechaFin;
                    if (difFecha >= 30)
                    {
                        fechaFin = capacitaempleado.FechaInicio.AddDays(configBuscar.PlazoCertificaOperAntiguo);
                        capacitaempleado.FechaFin = fechaFin;
                    }
                    else
                    {
                        fechaFin = capacitaempleado.FechaInicio.AddDays(configBuscar.PlazoCertificaOperNuevo);
                        capacitaempleado.FechaFin = fechaFin;
                    }
                }

                CapacitacionEmpleado newObjEntity = new();
                newObjEntity.IdEmpleado = capacitaempleado.IdEmpleado;
                newObjEntity.Pieza = capacitaempleado.Pieza;
                newObjEntity.IdProceso = capacitaempleado.IdProceso;
                newObjEntity.Maquina = capacitaempleado.Maquina;
                newObjEntity.IdNivelCertificacion = capacitaempleado.IdNivelCertificacion+1;
                newObjEntity.IdMentor = capacitaempleado.IdMentor;
                newObjEntity.FechaInicio = capacitaempleado.FechaInicio;
                newObjEntity.FechaFin = capacitaempleado.FechaFin;
                newObjEntity.Turno = capacitaempleado.Turno;
                newObjEntity.Concluida = false;
                newObjEntity.Activo = capacitaempleado.Activo;

                long respNewEntity = procesoData.Addentity(newObjEntity, ip);
                if (respNewEntity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                /*}
                else
                {
                    respAltaProceso.Id = -1;
                    respAltaProceso.Codigo = "-1";
                    respAltaProceso.Mensaje ="Proceso Duplicado";
                    return respAltaProceso;

                }*/
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
