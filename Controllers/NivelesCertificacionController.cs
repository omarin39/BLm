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
    public class NivelesCertificacionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessNivelesCertificacion procNivelesCertificacion = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public NivelesCertificacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestNivelesCertificacion req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.NombreNivelCertificacion != null)
                {
                    var result = procNivelesCertificacion.AddNivelesCertificacion(req, remoteIpAddress.ToString()); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("NivelesCertificacion not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("NivelesCertificacion not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("NivelesCertificacion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestNivelesCertificacion> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("NivelesCertificacion not found");
                }
                else
                {
                    var result = procNivelesCertificacion.FindNivelesCertificacion(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<NivelCertificacion>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                 List<NivelCertificacion> result = procNivelesCertificacion.FindAllNivelesCertificacion();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestNivelesCertificacion req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                ResponseGral result = procNivelesCertificacion.UpdateNivelesCertificacion(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("NivelesCertificacion not found");
                    }

                
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }




    }
}
