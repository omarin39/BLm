using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;


namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpProcesoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessOpProceso procProceso = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public OpProcesoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestOpProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                if (req.Codigo != null)
                {
                    var result = procProceso.AddProceso(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("OpProceso not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("OpProceso not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("OpProceso not found");
              
            }
         
        }


        [HttpGet("{opProceso}")]
        public ActionResult<RequestOpProceso> Find(string opProceso)
        {
            try
            {
                if (opProceso == "")
                {
                    return NotFound("OpProceso not found");
                }
                else
                {
                    var result = procProceso.FindProceso(opProceso);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("OpProceso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("OpProceso not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<OperacionProceso>> FindAll()
        {
            try
            {
               
                List<OperacionProceso> result = procProceso.FindAllProceso();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("OpProceso not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("OpProceso not found");
               
            }
         
        }

      /*  [HttpGet("FindProcesoAutoComplete/{param}")]
        public ActionResult<List<ResponseOpProceso>> FindProcesoAutoComplete(String param)
        {
            try
            {
                if (param==null)
                {
                    return NotFound("OpProceso not found");
                }

                if (param.Trim().Equals(""))
                {
                    return NotFound("OpProceso not found");
                }

                List<ResponseOpProceso> result = procProceso.FindProcesoAutoComplete(param);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("OpProceso not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("OpProceso not found");

            }

        }
        */

        [HttpPut()]
        public ActionResult Put([FromBody] RequestOpProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procProceso.UpdateProceso(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("OpProceso not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("OpProceso not found");

            }

        }




    }
}
