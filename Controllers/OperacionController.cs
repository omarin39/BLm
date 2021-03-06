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
    public class OperacionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessOperacion procOperacion = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public OperacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestOperacion req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.Operacion != null)
                {
                    var result = procOperacion.AddOperacion(req, remoteIpAddress.ToString()); 
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Operacion not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Operacion not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Operacion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestOperacion> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Operacion not found");
                }
                else
                {
                    var result = procOperacion.FindOperacion(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Operacion>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
           

            try
            {
                 List<Operacion> result = procOperacion.FindAllOperacion();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestOperacion req)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();


            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                ResponseGral result = procOperacion.UpdateOperacion(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Operacion not found");
                    }

                
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Operacion not found");
               
            }
         
        }




    }
}
