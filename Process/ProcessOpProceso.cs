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
    public class ProcessOpProceso
    {       
        public DataOpProceso ProcesoData = new();
        public ResponseGral AddProceso(RequestOpProceso Proceso, String ip)
        {
            ResponseGral respAltaProceso = new();
            try
            {
                if ( ProcesoData.ValidaClaveExistente(Proceso)==false ) {
                
               
                    OperacionProceso logNewRegistro = new();
                    logNewRegistro.IdProceso = Proceso.IdProceso;
                    logNewRegistro.Descripcion = Proceso.Descripcion;
                    logNewRegistro.Codigo= Proceso.Codigo;
                    logNewRegistro.Nombre = Proceso.Nombre;
                    logNewRegistro.Activo = Proceso.Activo;
                    long respNewUSR = ProcesoData.AddProceso(logNewRegistro,ip);
                    if(respNewUSR >0)
                    {
                        respAltaProceso.Id = respNewUSR;
                        respAltaProceso.Codigo = "200";
                        respAltaProceso.Mensaje = "OK";
                        return respAltaProceso;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    respAltaProceso.Id = -1;
                    respAltaProceso.Codigo = "-1";
                    respAltaProceso.Mensaje ="OPProceso Duplicado";
                    return respAltaProceso;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateProceso( RequestOpProceso Proceso, String ip)
        {
            ResponseGral respAltaProceso = new();
            var ProcesoBuscado = FindProceso(Proceso.Codigo);
            if (ProcesoBuscado == null)
            {
                return respAltaProceso;
            }
            else if (ProcesoBuscado.IdProceso == -1)
            {
                respAltaProceso.Id = ProcesoBuscado.IdProceso;
                respAltaProceso.Codigo = "400";
                respAltaProceso.Mensaje = "Record not found";
                return respAltaProceso;
            }
            else
            {
                try
                {
                    if (ProcesoData.ValidaClaveExistente(Proceso) == false)
                    {
                        ProcesoBuscado.IdProceso = Proceso.IdProceso;
                        ProcesoBuscado.Nombre = Proceso.Nombre;
                        ProcesoBuscado.Descripcion = Proceso.Descripcion;
                        ProcesoBuscado.Codigo = Proceso.Codigo;
                        ProcesoBuscado.Nombre = Proceso.Nombre;
                        ProcesoBuscado.Activo = Proceso.Activo;
                        var respNewProceso = ProcesoData.UpdateProceso(ProcesoBuscado, ip);
                        if (respNewProceso > 0)
                        {
                            respAltaProceso.Id = ProcesoBuscado.IdProceso;
                            respAltaProceso.Codigo = "200";
                            respAltaProceso.Mensaje = "OK";
                            return respAltaProceso;
                        }
                        else
                        {
                            respAltaProceso.Id = ProcesoBuscado.IdProceso;
                            respAltaProceso.Codigo = "400";
                            respAltaProceso.Mensaje = "Record not found";
                            return respAltaProceso;
                        }
                    }
                    else
                    {
                        respAltaProceso.Id = -1;
                        respAltaProceso.Codigo = "-1";
                        respAltaProceso.Mensaje = "Duplicidad";
                        return respAltaProceso;
                    }
                }
                catch (Exception ex)
                {
                    respAltaProceso.Id = ProcesoBuscado.IdProceso;
                    respAltaProceso.Codigo = "400";
                    respAltaProceso.Mensaje = ex.InnerException.Message;
                    return respAltaProceso;
                }
            }
        }

        internal List<ResponseOpProceso> FindProcesoAutoComplete(string param)
        {
            List<OperacionProceso> resPiezaRet = ProcesoData.FindProcesoAutoComplete(param);

            var result = resPiezaRet.Select((proc, i) =>
                    new ResponseOpProceso
                    {
                      Nombre=proc.Nombre,
                      Codigo=proc.Codigo,
                      Descripcion=proc.Descripcion,
                      //Dificultad=proc.Dificultad,
                      IdProceso=proc.IdProceso
                    }).ToList();
            return result;
        }

        public OperacionProceso FindProceso(String Proceso){
            OperacionProceso respAltaProceso = ProcesoData.FindProceso(Proceso);
            if (respAltaProceso == null)
            {
                respAltaProceso = new OperacionProceso();
                respAltaProceso.IdProceso = -1;
            }
            return respAltaProceso;
        }
    


    public List<OperacionProceso> FindAllProceso()
    {
        List<OperacionProceso> resProcesoRet = ProcesoData.FindAllProcesos();
        return resProcesoRet;
    }


}
}
