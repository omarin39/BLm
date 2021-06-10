using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
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
        public ResponseGral AddCapacitacionEmpleado(RequestCapacitacionEmpleado inputEntity, String ip)
        {
            ResponseGral respAltaProceso = new();
            try
            {
               // if ( ProcesoData.ValidaClaveExistente(inputEntity) ==false ) {
                
               
                    CapacitacionEmpleado newObjEntity = new();
                    newObjEntity.IdEmpleado = inputEntity.IdEmpleado;
                    newObjEntity.Pieza = inputEntity.Pieza;
                    newObjEntity.IdProceso= inputEntity.IdProceso;
                    newObjEntity.Maquina = inputEntity.Maquina;
                    newObjEntity.IdNivelCertificacion = inputEntity.IdNivelCertificacion;
                    newObjEntity.IdMentor = inputEntity.IdMentor;
                    newObjEntity.FechaInicio = inputEntity.FechaInicio;
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
   
        public List<CapacitacionEmpleado> FindAllCapacitacionEmpleado()
    {
        List<CapacitacionEmpleado> resProcesoRet = procesoData.FindAllCapacitacionEmpleado();
        return resProcesoRet;
    }

}
}
