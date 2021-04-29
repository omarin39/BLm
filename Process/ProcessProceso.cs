using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessProceso
    {       
        public DataProceso ProcesoData = new();
        public ResponseGral AddProceso(RequestProceso Proceso, String ip)
        {
            ResponseGral respAltaProceso = new();
            try
            {
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
                    return respAltaProceso;
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

        public ResponseGral UpdateProceso( RequestProceso Proceso, String ip)
        {
            ResponseGral respAltaProceso = new();
            var ProcesoBuscado = FindProceso(Proceso.Codigo);
            if (ProcesoBuscado == null)
            {
                return respAltaProceso;
            }
            else
            {
                try
                {
                    ProcesoBuscado.Nombre = Proceso.Nombre;
                    ProcesoBuscado.Descripcion = Proceso.Descripcion;
                    ProcesoBuscado.Codigo = Proceso.Codigo;
                    ProcesoBuscado.Activo = Proceso.Activo;
                    var respNewProceso = ProcesoData.UpdateProceso(ProcesoBuscado,ip);
                    if (respNewProceso > 0)
                    {
                        respAltaProceso.Id = ProcesoBuscado.IdProceso;
                        respAltaProceso.Codigo = "200";
                        return respAltaProceso;
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
        public Proceso FindProceso(String Proceso){
            Proceso respAltaProceso = ProcesoData.FindProceso(Proceso);
            if (respAltaProceso == null)
            {
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
