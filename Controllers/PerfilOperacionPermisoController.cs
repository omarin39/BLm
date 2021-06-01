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
    public class PerfilOperacionPermisoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPerfilOperacionPermiso procPerfilOperacionPermiso = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PerfilOperacionPermisoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPerfilOperacionPermiso req)
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            try
            {
               

                if (req.IdPerfil != null)
                {
                    var result = procPerfilOperacionPermiso.AddPerfilOperacionPermiso(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("PerfilOperacionPermiso not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("PerfilOperacionPermiso not found");
              
            }
         
        }


        [HttpPost("PostPerfilOperacionPermiso")]
        public ActionResult Post([FromBody] List<RequestPerfilOperacionPermisoItem> req)
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            try
            {
               

                if (req.Count > 0)
                {
                    var result = procPerfilOperacionPermiso.AddPerfilOperacionPermisoList(req, remoteIpAddress.ToString());
                    return Ok(result);

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("PerfilOperacionPermiso not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("PerfilOperacionPermiso not found");

            }

        }





        [HttpGet("{id}")]
        public ActionResult<RequestPerfilOperacionPermiso> Find(long idPerfil) //idPerfil
        {
            try
            {
                if (idPerfil <= 0)
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }
                else
                {
                    var result = procPerfilOperacionPermiso.FindPerfilOperacionPermiso(idPerfil);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
               
            }
         
        }


       
        [HttpGet("FindPorPerfil/{idPerfil}")]
        public ActionResult<List<ResponsePerfilOperacionPermisoJoined>> FindPorPerfil(long idPerfil) 
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();


            try
            {
                if (idPerfil <= 0)
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }
                else
                {
                    var result = procPerfilOperacionPermiso.FindPerfilOperacionPermisoJoined(idPerfil);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<PerfilOperacionPermiso>> FindAll() 
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
           

            try
            {
                 List<PerfilOperacionPermiso> result = procPerfilOperacionPermiso.FindAllPerfilOperacionPermiso();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestPerfilOperacionPermiso reqPerfilOperacionPermiso)
        {
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
                ResponseGral result = procPerfilOperacionPermiso.UpdatePerfilOperacionPermiso(reqPerfilOperacionPermiso, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }
            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
            }
        }
    }
}
