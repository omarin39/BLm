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
    public class CapacitacionEmpleadoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessCapacitacionEmpleado procCapacitacionEmpleado = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public CapacitacionEmpleadoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestCapacitacionEmpleado req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                if (req.IdEmpleado > 0)
                {
                    var result = procCapacitacionEmpleado.AddCapacitacionEmpleado(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("CapacitacionEmpleado not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("CapacitacionEmpleado not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("CapacitacionEmpleado not found");
              
            }
         
        }


        [HttpGet("{idEmpleado}")]
        public ActionResult<RequestCapacitacionEmpleado> Find(long idEmpleado)
        {
            try
            {
                if (idEmpleado == null)
                {
                    return NotFound("CapacitacionEmpleado not found");
                }
                else
                {
                    var result = procCapacitacionEmpleado.FindCapacitacionEmpleado(idEmpleado);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("CapacitacionEmpleado not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("CapacitacionEmpleado not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<CapacitacionEmpleado>> FindAll()
        {
            try
            {
               
                List<CapacitacionEmpleado> result = procCapacitacionEmpleado.FindAllCapacitacionEmpleado();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("CapacitacionEmpleado not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("CapacitacionEmpleado not found");
               
            }
         
        }



        [HttpPut()]
        public ActionResult Put([FromBody] RequestCapacitacionEmpleado req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procCapacitacionEmpleado.UpdateCapacitacionEmpleado(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("CapacitacionEmpleado not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("CapacitacionEmpleado not found");

            }

        }




    }
}
