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
    public class EmpleadoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessEmpleado ProcEmpleado = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public EmpleadoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestEmpleado req)
        {
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

                if (req.Nombre != null)
                {
                    var result = ProcEmpleado.AddEmpleado(req, remoteIpAddress.ToString()); 
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Empleado not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Empleado not found");
                }
               
            }
            catch (Exception e)
            {

                return NotFound(e.Message.ToString());
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestEmpleado> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Empleado not found");
                }
                else
                {
                    var result = ProcEmpleado.FindEmpleado(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
               
            }
         
        }

        [HttpGet("FindAllEmpleadosPorPerfil/{idPerfil}")]
        public ActionResult<List<Empleado>> FindAllEmpleadosPorPerfil(long idPerfil)
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();


            try
            {
                if (idPerfil <= 0)
                {
                    return NotFound("Empleado not found");
                }
                else
                {
                    var result = ProcEmpleado.FindAllEmpleadosPorPerfil(idPerfil);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }
                }
            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
            }
        }

        [HttpGet()]
        public ActionResult<List<Empleado>> FindAll()
        {
            try
            {
                 List<Empleado> result = ProcEmpleado.FindAllEmpleado();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
               
            }
         
        }

        [HttpPut()]
         public ActionResult Put([FromBody] RequestEmpleado req)
        
        { 
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = ProcEmpleado.UpdateEmpleado(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Empleado not found");
                    }

                
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Empleado not found");
               
            }
         
        }




    }
}
