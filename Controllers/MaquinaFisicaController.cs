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
    public class MaquinaFisicaController : ControllerBase
    {
        
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessMaquinaFisica process = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public MaquinaFisicaController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestMaquinaFisica req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.Ubicacion != null)
                {
                    var result = process.AddMaquinaFisica(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Maquina Fisica not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Maquina Fisica not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Maquina Fisica not found");

            }

        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestMaquinaFisica req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdateMaquinaFisica(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Maquina Fisica not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Maquina Fisica not found");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<MaquinaFisica> Find(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Maquina Fisica not found");
                }
                else
                {
                    var result = process.FindOnlyMaquinaPorId(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Maquina Fisica not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Maquina Fisica not found");

            }

        }

        [HttpGet()]
        public ActionResult<List<ResponseMaquinaFisica>> FindAll()
        {
            try
            {

                List<ResponseMaquinaFisica> result = process.FindAllMaquinaFisica();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Maquina Fisica not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Maquina Fisica not found");

            }

        }

    }
}
