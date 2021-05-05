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
    public class ClienteController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessCliente procCliente = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new();


        public ClienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestCliente ReqCliente)
        {

            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            try
            {
                if (ReqCliente.Nombre != null)
                {
                    var result = procCliente.AddCliente(ReqCliente, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(ReqCliente, System.Reflection.MethodBase.GetCurrentMethod().Name),"Error al realizar la operación", 401);
                        return NotFound("Cliente not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(ReqCliente, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);

                    return NotFound("Cliente not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(ReqCliente, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Cliente not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestCliente> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Cliente not found");
                }
                else
                {
                    var result = procCliente.FindCliente(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Cliente not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Cliente not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Cliente>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                 List<Cliente> result = procCliente.FindAllCliente();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Cliente not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Cliente not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestCliente ReqCliente)
        {
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
                ResponseGral result = procCliente.UpdateCliente(ReqCliente, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Cliente not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Cliente not found");
               
            }
         
        }




    }
}
