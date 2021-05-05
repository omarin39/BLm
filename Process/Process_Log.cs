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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class Process_Log
    {       
        public DataLog logData = new();

        //rlog, NewNave.ToString(), "OK", 200
        public ResponseGral AddLog(String ip, String data, String respuesta, int codigo)
        {
            ResponseGral respAltaLog = new();
            try
            {
                ProcessLog logNewRegistro = new();
                logNewRegistro.Data = data;
                logNewRegistro.Codigo = codigo;
                logNewRegistro.Fecha = System.DateTime.Now;
                logNewRegistro.Ip = ip;
                logNewRegistro.Respuesta = respuesta;
                long respNewItem = logData.AddLog(logNewRegistro);
                if(respNewItem > 0)
                {
                    respAltaLog.Id = respNewItem;
                    respAltaLog.Codigo = "200";
                    respAltaLog.Mensaje = "OK";
                    return respAltaLog;
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

        public ResponseGral AddLog(RequestLog log)
        {
            ResponseGral respAltaLog = new();
            try
            {
                ProcessLog logNewRegistro = new();
                logNewRegistro.Data = log.Data;
                logNewRegistro.Codigo = log.Codigo;
                logNewRegistro.Fecha = System.DateTime.Now;
                logNewRegistro.Ip = log.Ip;
                logNewRegistro.Respuesta = log.Respuesta;
                long respNewItem = logData.AddLog(logNewRegistro);
                if (respNewItem > 0)
                {
                    respAltaLog.Id = respNewItem;
                    respAltaLog.Codigo = "200";
                    respAltaLog.Mensaje = "OK";
                    return respAltaLog;
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


        public ResponseProcessLogDate FindLog(long IdLog){
            ProcessLog respAltaLog = logData.FindLog(IdLog);
            if (respAltaLog == null)
            {
                respAltaLog = new ProcessLog();
                respAltaLog.Id = -1;
            }

            var result = new ResponseProcessLogDate
                     {
                         Id = respAltaLog.Id,
                         IP = respAltaLog.Ip,
                         Fecha = respAltaLog.Fecha.ToString("yyyy/MM/dd HH:mm:ss"),
                         Data = respAltaLog.Data,
                         Respuesta = respAltaLog.Respuesta,
                         Codigo = respAltaLog.Codigo
                     };

            return result;
            
        }



        public List<ResponseProcessLogDate> FindAllLog()
        {
            List<ProcessLog> resLogRet = logData.FindAllLogs();


            var result = resLogRet.Select((Log, i) =>
                      new ResponseProcessLogDate
                      {
                          Id = Log.Id,
                          IP = Log.Ip,
                          Fecha = Log.Fecha.ToString("yyyy/MM/dd HH:mm:ss"),
                          Data = Log.Data,
                          Respuesta = Log.Respuesta,
                          Codigo = Log.Codigo
                      }).ToList();


            return result;
        }

        public  String GetPropertyValues(Object obj, string operacion)
        {
            Type t = obj.GetType();
           
            PropertyInfo[] props = t.GetProperties();
            StringBuilder resultado = new StringBuilder();
          
            resultado.Append("Operation (OPERACIÓN = " + operacion + ")");
            resultado.Append("Type: "+ t.Name);
            resultado.Append("Properties (N = "+ props.Length +")");

            foreach (var prop in props) {
                if (prop.GetIndexParameters().Length == 0)
                {
                  
                    if (prop.PropertyType.Name.StartsWith("ICollection")) continue;
                    resultado.AppendLine("  "+ prop.Name + " (" + prop.PropertyType.Name + "): "+ prop.GetValue(obj));
                }
               /* else { 
                    resultado.AppendLine("   "+ prop.Name + " ("+ prop.PropertyType.Name + "): <Indexed>");
                }*/
            }


            return resultado.ToString();
        }


    }
}
