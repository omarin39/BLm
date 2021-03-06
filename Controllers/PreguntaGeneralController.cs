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
    public class PreguntaGeneralController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaGeneral process = new();

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


                if (req.Pregunta != null)
                {
                    var result = process.AddPreguntaGeneral(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Pregunta Proceso not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Pregunta Proceso not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta Proceso not found");

            }

        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaGeneral req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdatePreguntaGeneral(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Pregunta Proceso not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta Proceso not found");

            }

        }

        [HttpGet("{id}")]
        public ActionResult<PreguntaGeneral> Find(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Pregunta Proceso not found");
                }
                else
                {
                    var result = process.FindPreguntaGeneral(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pregunta Proceso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta Proceso not found");

            }

        }

        [HttpGet("FindPreguntaGeneral/{TipoPregunta}")]
        public ActionResult<List<RequestPreguntaGeneral>> FindPreguntaProceso(long TipoPregunta)
        {
            try
            {
                var result = process.FindPreguntaGeneralByTipo(TipoPregunta);
                if (result == null)
                {
                    return NotFound("Pregunta General not found");
                }
                else
                {
                    
                    return Ok(result);

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta General not found");

            }

        }



        [HttpGet()]
        public ActionResult<List<PreguntaGeneral>> FindAll()
        {
            try
            {

                List<PreguntaGeneral> result = process.FindAllPreguntaGeneral();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Pregunta Proceso not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pregunta Proceso not found");

            }

        }

    }
}
