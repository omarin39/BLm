using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessProcessLog
    {
        private ResponseProcessLog ResponseWS = new();
       
        public DataProcessLog processLogData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseGral AddProcessLog(RequestProcessLog processLog)
        {
            ResponseGral respAltaProcessLog = new();
            try
            {
                ProcessLog logNewRegistro = new();
                logNewRegistro.Ip = processLog.IP;
                logNewRegistro.Fecha = processLog.Fecha;
                logNewRegistro.Data = processLog.Data;
                logNewRegistro.Respuesta = processLog.Respuesta;
                logNewRegistro.Codigo= processLog.Codigo;
                long respNewUSR = processLogData.AddProcessLog(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaProcessLog.Id = respNewUSR;
                    respAltaProcessLog.Codigo = "200";
                    return respAltaProcessLog;
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

        public ResponseGral UpdateProcessLog( RequestProcessLog processLog)
        {
            ResponseGral respAltaProcessLog = new();
            var processLogBuscado = FindProcessLog(processLog.Id);
            if (processLogBuscado == null)
            {
                return respAltaProcessLog;
            }
            else
            {
                try
                {
                    processLogBuscado.Ip = processLog.IP;
                    processLogBuscado.Fecha = processLog.Fecha;
                    processLogBuscado.Data = processLog.Data;
                    processLogBuscado.Respuesta = processLog.Respuesta;
                    processLogBuscado.Codigo = processLog.Codigo;
                    var respNewLOG = processLogData.UpdateProcessLog(processLogBuscado);
                    if (respNewLOG > 0)
                    {
                        respAltaProcessLog.Id = processLogBuscado.Id;
                        respAltaProcessLog.Codigo = "200";
                        return respAltaProcessLog;
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

        public ProcessLog FindProcessLog(long idProcessLog){
            ProcessLog respAltaProcessLog = processLogData.FindProcessLog(idProcessLog);
            if(respAltaProcessLog==null){
                respAltaProcessLog.Id = -1;
            }
            return respAltaProcessLog;
        }

         public List<ProcessLog> FindAllProcessLog(){
            List<ProcessLog> resProcessLogRet = processLogData.FindAllProcessLog();
            return resProcessLogRet;
        }

       


    }
}
