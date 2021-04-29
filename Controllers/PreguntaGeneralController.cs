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
    public class PreguntaGeneralController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaGeneral procPreguntaGeneral = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PreguntaGeneralController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaGeneral req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                if (req.pregunta != null)
                {
                    var result = procPreguntaGeneral.AddPreguntaGeneral(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("PreguntaGeneral not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("PreguntaGeneral not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("PreguntaGeneral not found");
              
            }
         
        }





        [HttpGet("{preguntaGeneral}")]
        public ActionResult<RequestPreguntaGeneral> Find(string preguntaGeneral)
        {
            try
            {
                if (preguntaGeneral == "")
                {
                    return NotFound("PreguntaGeneral not found");
                }
                else
                {
                    var result = procPreguntaGeneral.FindPreguntaGeneral(preguntaGeneral);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PreguntaGeneral not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<PreguntasPtGenerale>> FindAll()
        {
            try
            {
               
                List<PreguntasPtGenerale> result = procPreguntaGeneral.FindAllPreguntaGeneral();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PreguntaGeneral not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaGeneral req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procPreguntaGeneral.UpdatePreguntaGeneral(req, remoteIpAddress.ToString());
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
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("PreguntaGeneral not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("PreguntaGeneral not found");

            }

        }




    }
}
