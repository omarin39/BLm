using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using NWebsec.AspNetCore.Core.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;


namespace APIRest.Controllers
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
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public ClienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestCliente ReqCliente)
        {

            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;


            List<ResponseCliente> ResponseWS = new();
            ResponseCliente ComplementoResponseWS = new();
  

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
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(ReqCliente, System.Reflection.MethodBase.GetCurrentMethod().Name),"Error al contactar el server", 401);
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
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(ReqCliente, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
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
            List<ResponseCliente> ResponseWS = new();
            ResponseCliente ComplementoResponseWS = new();
           

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
