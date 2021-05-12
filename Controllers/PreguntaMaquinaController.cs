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
    public class PreguntaMaquinaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaMaquina process = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PreguntaMaquinaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.Pregunta != null)
                {
                    var result = process.AddPreguntaMaquina(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("PreguntaMaquina not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("PreguntaMaquina not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("PreguntaMaquina not found");
              
            }
         
        }


        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdatePreguntaMaquina(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Pregunta not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta not found");

            }

        }


        [HttpGet("{id}")]
        public ActionResult<PreguntaMaquina> Find(long id) 
        {
            try
            {
                if (id <=0)
                {
                    return NotFound("PreguntaMaquina not found");
                }
                else
                {
                    var result = process.findTipoAcceosPorId(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PreguntaMaquina not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PreguntaMaquina not found");
               
            }
         
        }

     

        [HttpGet()]
        public ActionResult<List<PreguntaMaquina>> FindAll()
        {
            try
            {
               
                List<PreguntaMaquina> result = process.FindAllPreguntaMaquina();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PreguntaMaquina not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PreguntaMaquina not found");
               
            }
         
        }







    }
}
