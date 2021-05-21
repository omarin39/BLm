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
    public class PreguntaProcesoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaProceso process = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public PreguntaProcesoController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.Pregunta != null)
                {
                    var result = process.AddPreguntaProceso(req, remoteIpAddress.ToString());
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
        public ActionResult Put([FromBody] RequestPreguntaProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdatePreguntaProceso(req, remoteIpAddress.ToString());
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
        public ActionResult<PreguntaProceso> Find(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Pregunta Proceso not found");
                }
                else
                {
                    var result = process.FindPreguntaProcesoById(id);
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

        [HttpGet("FindPreguntaProcesoProceso/{Proceso}")]
        public ActionResult<List<RequestPreguntaProceso>> FindPreguntaProceso(long Proceso)
        {
            try
            {

                if (Proceso <= 0)
                {
                    return NotFound("Pregunta Proceso not found");
                }
                else
                {
                    var result = process.FindPreguntaProcesoByProceso(Proceso);
                    return Ok(result);

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta Proceso not found");

            }

        }



        [HttpGet()]
        public ActionResult<List<PreguntaProceso>> FindAll()
        {
            try
            {

                List<PreguntaProceso> result = process.FindAllPreguntaProceso();
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
