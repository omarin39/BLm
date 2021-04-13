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
        public ResponseGral AddProceso(RequestProceso Proceso)
        {
            ResponseGral respAltaProceso = new();
            try
            {
                Proceso logNewRegistro = new();
                logNewRegistro.Nombre = Proceso.nombre;
                logNewRegistro.Descripcion = Proceso.descripcion;
                logNewRegistro.Activo = Proceso.Activo;
                long respNewUSR = ProcesoData.AddProceso(logNewRegistro);
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

        public ResponseGral UpdateProceso( RequestProceso Proceso)
        {
            ResponseGral respAltaProceso = new();
            var ProcesoBuscado = FindProceso(Proceso.nombre);
            if (ProcesoBuscado == null)
            {
                return respAltaProceso;
            }
            else
            {
                try
                {
                    ProcesoBuscado.Nombre = Proceso.nombre;
                    ProcesoBuscado.Descripcion = Proceso.descripcion;
                    ProcesoBuscado.Activo = Proceso.Activo;
                    var respNewProceso = ProcesoData.UpdateProceso(ProcesoBuscado);
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
