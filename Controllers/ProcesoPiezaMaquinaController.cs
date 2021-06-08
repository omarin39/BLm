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
    public class ProcesoPiezaMaquinaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessProcesoPiezaMaquina process = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log(); 

        public ProcesoPiezaMaquinaController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestProcesoPiezaMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                var result = process.AddProcesoPiezaMaquina(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Proceso Pieza Maquina found");
                }
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Proceso Pieza Maquina not found");

            }
        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestProcesoPiezaMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdateProcesoPiezaMaquina(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Proceso Pieza Maquina not Found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Proceso Pieza Maquina not Found");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProcesoPiezaMaquina> Find(long id)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound("Proceso Pieza Maquina not Found");
                }
                else
                {
                    var result = process.FindProcesoPiezaById(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Proceso Pieza Maquina not found");
                    }

                }
            }
            catch (Exception e)
            {
                return NotFound("Proceso Pieza Maquina not Found");

            }
        }

        [HttpGet()]
        public ActionResult<List<ResponseProcesoPiezaMaquina>> FindAll()
        {
            try
            {
                List<ResponseProcesoPiezaMaquina> result = process.FindAllProcesoPiezaMaquina();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Proceso Pieza Maquina not Found");
                }
            }
            catch (Exception e)
            {
                return NotFound("Proceso Pieza Maquina not Found");

            }
        }

        [HttpGet("FindProcesoPiezaMaquina/{ProcesoMaquina}")]
        public ActionResult<List<ResponseProcesoPiezaMaquina>> FindPiezaProceso(long ProcesoMaquina)
        {
            try
            {
                if (ProcesoMaquina <= 0)
                {
                    return NotFound("Proceso Pieza Maquina not Found");
                }
                else
                {
                    var result = process.FindProcesoPiezaoByMaquinaProceso(ProcesoMaquina);
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return NotFound("Proceso Pieza Maquina not Found");
            }
        }

    }
}
