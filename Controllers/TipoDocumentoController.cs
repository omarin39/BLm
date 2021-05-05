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
    public class TipoDocumentoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessTipoDocumento procTipoDocumento = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public TipoDocumentoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestTipoDocumento req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
              

                if (req.Descripcion != null)
                {
                    var result = procTipoDocumento.AddTipoDocumento(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("TipoDocumento not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("TipoDocumento not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("TipoDocumento not found");
              
            }
         
        }





        [HttpGet("{tipoDocumento}")]
        public ActionResult<RequestTipoDocumento> Find(string tipoDocumento)
        {
            try
            {
                if (tipoDocumento == null)
                {
                    return NotFound("TipoDocumento not found");
                }
                else
                {
                    var result = procTipoDocumento.FindTipoDocumento(tipoDocumento);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("TipoDocumento not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("TipoDocumento not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<TipoDocumento>> FindAll()
        {
            try
            {
               
                List<TipoDocumento> result = procTipoDocumento.FindAllTipoDocumento();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("TipoDocumento not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("TipoDocumento not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestTipoDocumento req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procTipoDocumento.UpdateTipoDocumento(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else if (result.Codigo == "503")
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("TipoDocumento not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("TipoDocumento not found");

            }

        }




    }
}
