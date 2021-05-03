﻿using APIRestV2.Common;
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
    public class PreguntaPtGeneralController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaPtGeneral procPreguntaPtGeneral = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PreguntaPtGeneralController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaPtGeneral req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                if (req.pregunta != null)
                {
                    var result = procPreguntaPtGeneral.AddPregunta(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Pregunta not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Pregunta not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Pregunta not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPreguntaPtGeneral> Find(string Pregunta)
        {
            try
            {
                if (Pregunta == "")
                {
                    return NotFound("Pregunta not found");
                }
                else
                {
                    var result = procPreguntaPtGeneral.FindPregunta(Pregunta);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pregunta not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<PreguntaPtGeneral>> FindAll()
        {
            try
            {
               
                List<PreguntaPtGeneral> result = procPreguntaPtGeneral.FindAllPregunta();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Pregunta not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaPtGeneral req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procPreguntaPtGeneral.UpdatePregunta(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("Pregunta not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Pregunta not found");

            }

        }




    }
}
