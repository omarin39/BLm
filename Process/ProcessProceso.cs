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
    public class ProcessProceso
    {       
        public DataProceso ProcesoData = new();
        public ResponseGral AddProceso(RequestProceso Proceso, String ip)
        {
            ResponseGral respAltaProceso = new();
            try
            {
                if ( ProcesoData.ValidaClaveExistente(Proceso)==false ) {
                
               
                    Proceso logNewRegistro = new();
                    logNewRegistro.Nombre = Proceso.Nombre;
                    logNewRegistro.Descripcion = Proceso.Descripcion;
                    logNewRegistro.Codigo= Proceso.Codigo;
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
                    respAltaProceso.Mensaje ="Proceso Duplicado";
                    return respAltaProceso;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateProceso( RequestProceso Proceso, String ip)
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
        public Proceso FindProceso(String Proceso){
            Proceso respAltaProceso = ProcesoData.FindProceso(Proceso);
            if (respAltaProceso == null)
            {
                respAltaProceso = new Proceso();
                respAltaProceso.IdProceso = -1;
            }
            return respAltaProceso;
        }
    


    public List<Proceso> FindAllProceso()
    {
        List<Proceso> resProcesoRet = ProcesoData.FindAllProcesos();
        return resProcesoRet;
    }


}
}
