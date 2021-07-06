using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaProcesoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessMaquinaProceso process = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public MaquinaProcesoController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestMaquinaProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                var result = process.AddMaquinaProceso(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Maquina Proceso not found");
                }
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Maquina Proceso not found");

            }
        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestMaquinaProceso req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdateMaquinaProceso(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Maquina Proceso not Found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Maquina Proceso not Found");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<MaquinaProceso> Find(long id)
        {
            try
            {
                if (id <0)
                {
                    return NotFound("Maquina Proceso not Found");
                }
                else
                {
                    var result = process.FindMaquinaProcesoByID(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Proceso not found");
                    }

                }
            }
            catch (Exception e)
            {
                return NotFound("Maquina Proceso not Found");

            }
        }


        [HttpGet()]
        public ActionResult<List<MaquinaProceso>> FindAll()
        {
            try 
            {
                List<MaquinaProceso> result = process.FindAllMaquinaProceso();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Maquina Proceso not Found");
                }
            }
            catch (Exception e)
            {
                return NotFound("Maquina Proceso not Found");

            }
        }

        [HttpGet("FindProcesoMaquina/{Maquina}")]
        public ActionResult<List<ResponseMaquinaProceso>> FindMaquinaProceso(long Maquina)
        {
            try
            {
                if (Maquina <= 0)
                {
                    return NotFound("Maquina Proceso not found");
                }
                else
                {
                        var result = process.FindMaquinaProceso(Maquina);
                        return Ok(result);
                }
            }catch(Exception e)
            {
                return NotFound("Maquina Proceso not Found");
            }
        }

        [HttpGet("FindMaquinaAsignaCapacitacion")]
        public ActionResult<List<VwMaquinaasignacapacitacion>> FindMaquinaAsignaCapacitacion()
        {
            try
            {
                var result = process.FindMaquinaAsignaCapacitacion();
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Maquina Proceso not Found");
            }
        }

        [HttpGet("FindMaquinaProcesosAsignaCapacitacion/{IdMaquina}")]
        public ActionResult<List<VwMaquinaprocesoasignacapacitacion>> FindMaquinaProcesosAsignaCapacitacion(long IdMaquina)
        {
            try
            {
                var result = process.FindMaquinaProcesosAsignaCapacitacion(IdMaquina);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Maquina Proceso not Found");
            }
        }

        [HttpGet("FindMaquinaProcesoPiezasAsignaCapacitacion/{IdMaquinaProceso}")]
        public ActionResult<List<VwMaquinaprocesopiezaasignacapacitacion>> FindMaquinaProcesoPiezasAsignaCapacitacion(long IdMaquinaProceso)
        {
            try
            {
                var result = process.FindMaquinaProcesoPiezasAsignaCapacitacion(IdMaquinaProceso);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Maquina Proceso not Found");
            }
        }
    }
}
