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
    public class ProcessProcessLog
    {
        private ResponseProcessLog ResponseWS = new();
       
        public DataProcessLog processLogData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseProcessLog AddProcessLog(RequestProcessLog processLog)
        {
            ResponseProcessLog respAltaProcessLog = new();
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
                    respAltaProcessLog.Id = respNewUSR.ToString();
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

        public ResponseProcessLog UpdateProcessLog( RequestProcessLog processLog)
        {
            ResponseProcessLog respAltaProcessLog = new();
            ProcessLog updAltaProcessLog = new();

            var processLogBuscado = FindProcessLog(processLog.Id);
            if(processLogBuscado==null){
                 return respAltaProcessLog;
            }else{
                try
                    {

                        processLogBuscado.Ip=processLog.IP;
                        processLogBuscado.Fecha=processLog.Fecha;
                        processLogBuscado.Data=processLog.Data;
                        processLogBuscado.Respuesta=processLog.Respuesta;
                        processLogBuscado.Codigo=processLog.Codigo;


                        var respNewLOG = processLogData.UpdateProcessLog(processLogBuscado);
                        if (respNewLOG > 0)
                        {
                            respAltaProcessLog.Id = processLogBuscado.Id.ToString();
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

            ProcessLog respAltaProcessLog = new();

            respAltaProcessLog = processLogData.FindProcessLog(idProcessLog);
            if(respAltaProcessLog==null){
                respAltaProcessLog.Id = -1;
            }
          
              return respAltaProcessLog;
        }

         public List<ProcessLog> FindAllProcessLog(){
            List<ProcessLog> resProcessLogRet = new List<ProcessLog>();
            resProcessLogRet =  processLogData.FindAllProcessLog();
           
            return resProcessLogRet;
        }

       


    }
}
