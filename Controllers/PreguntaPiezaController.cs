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
    public class PreguntaPiezaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaPieza process = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public PreguntaPiezaController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.Pregunta != null)
                {
                    var result = process.AddPreguntaPieza(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Pregunta Pieza not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Pregunta Pieza not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta Pieza not found");

            }

        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdatePreguntaPieza(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Pregunta Pieza not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta Pieza not found");

            }

        }

        [HttpGet("{id}")]
        public ActionResult<PreguntaProceso> Find(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Pregunta Pieza not found");
                }
                else
                {
                    var result = process.FindPreguntaPiezaById(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pregunta Pieza not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta Pieza not found");

            }

        }

        [HttpGet("FindPreguntaPiezaProcesoPiezaMaquina/{Proceso}")]
        public ActionResult<List<RequestPreguntaProceso>> FindPreguntaProceso(long Proceso)
        {
            try
            {

                if (Proceso <= 0)
                {
                    return NotFound("Pregunta Pieza not found");
                }
                else
                {
                    var result = process.FindPreguntaPiezaByProcesoPiezaMaquina(Proceso);
                    return Ok(result);

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta Proceso not found");

            }

        }

        [HttpGet("FindGlobalPiezaProcesoMaquinaIdNivelCertifica/{IdPieza}/{IdProceso}/{IdMaquina}/{IdNivelCertifica}/{IdIdioma}")]
        public ActionResult<List<ResponsePreguntasTotalesProcesos>> FindGlobalPiezaProcesoMaquinaIdNivelCertifica(string IdPieza,long IdProceso, string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {
            try
            {
                if (String.IsNullOrEmpty(IdMaquina) || String.IsNullOrWhiteSpace(IdMaquina))
                {
                    return NotFound("PreguntaMaquina not found");
                }
                else
                {
                    var result = process.FindGlobalPiezaProcesoMaquinaIdNivelCertifica(IdPieza, IdProceso, IdMaquina, IdNivelCertifica, IdIdioma);
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
        public ActionResult<List<PreguntaPieza>> FindAll()
        {
            try
            {

                List<PreguntaPieza> result = process.FindAllPreguntaPieza();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Pregunta Pieza not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pregunta Pieza not found");

            }

        }
    }
}
