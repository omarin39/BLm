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
    public class PiezaClienteController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPiezaCliente process = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PiezaClienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPiezaCliente req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.ClienteIdCliente > 0)
                {
                    var result = process.AddPiezaCliente(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("PiezaCliente not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("PiezaCliente not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("PiezaCliente not found");
              
            }
         
        }

        [HttpPut]
        public ActionResult Put([FromBody] RequestPiezaCliente req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.ClienteIdCliente > 0)
                {
                    var result = process.UpdatePiezasCliente(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("PiezaCliente not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("PiezaCliente not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("PiezaCliente not found");

            }

        }





        [HttpGet("{idPieza}")]
        public ActionResult<VwPiezaCliente> Find(long idPieza) 
        {
            try
            {
                if (idPieza <=0)
                {
                    return NotFound("PiezaClienteCliente not found");
                }
                else
                {
                    var result = process.FindClientesPorIdPieza(idPieza);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PiezaCliente not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PiezaCliente not found");
               
            }
         
        }

     

        [HttpGet()]
        public ActionResult<List<VwPiezaCliente>> FindAll()
        {
            try
            {
               
                List<VwPiezaCliente> result = process.FindAllPiezaCliente();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PiezaCliente not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PiezaCliente not found");
               
            }
         
        }







    }
}
