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
    public class MultimediaPiezaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessMultimediaPieza procMultimediaPieza = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public MultimediaPiezaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

       // [Consumes("multipart/form-data")]
        [HttpPost]
        public ActionResult Post([FromBody] RequestMultimediaPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
              

                if (req.Descripcion != null)
                {
                    var result = procMultimediaPieza.AddMultimediaPieza(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("MultimediaPieza not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("MultimediaPieza not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("MultimediaPieza not found");
              
            }
         
        }

        /*
        [HttpPost]
        public ActionResult Post([FromBody] RequestMultimediaPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.Descripcion != null)
                {
                    var result = procMultimediaPieza.AddMultimediaPieza(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("MultimediaPieza not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("MultimediaPieza not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("MultimediaPieza not found");

            }

        }*/


        [HttpGet("Find/{idPieza}/{TipoMedia}")]
        public ActionResult<RequestMultimediaPieza> Find(long idPieza, string TipoMedia)
        {
            try
            {
                if (idPieza ==0)
                {
                    return NotFound("MultimediaPieza not found");
                }
                else
                {
                    var result = procMultimediaPieza.FindMultimediaPiezaTipMedia(idPieza, TipoMedia);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("MultimediaPieza not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("MultimediaPieza not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<MultiMediaPieza>> FindAll()
        {
            try
            {
               
                List<MultiMediaPieza> result = procMultimediaPieza.FindAllMultimediaPieza();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("MultimediaPieza not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("MultimediaPieza not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestMultimediaPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procMultimediaPieza.UpdateMultimediaPieza(req, remoteIpAddress.ToString());
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
                    return NotFound("MultimediaPieza not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("MultimediaPieza not found");

            }

        }




    }
}
