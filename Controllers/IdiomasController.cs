using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using APIRestV2.Process;
using Microsoft.AspNetCore.Http;
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
    public class IdiomasController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessIdioma ProcIdioma = new();
        // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();
        public IdiomasController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestIdiomas req)
        {           
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
                if (req.Idioma1 != null)
                {
                    var result = ProcIdioma.AddIdioma(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Language not inserted");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Language required");
                }

            }
            catch (Exception e)
            {
                return NotFound("Language not found");

            }

        }
        [HttpGet("{id}")]
        public ActionResult<RequestIdiomas> Find(long id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Language not found");
                }
                else
                {
                    var result = ProcIdioma.FindIdioma(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Language not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Language not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<Idioma>> FindAll()
        {
            try
            {
                List<Idioma> result = ProcIdioma.FindAllIdioma();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Language not found");
                }
            }
            catch (Exception e)
            {
                return NotFound("Language not found");

            }

        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestIdiomas req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                ResponseGral result = ProcIdioma.UpdateIdioma(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("Language not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Language not found");

            }

        }


    }
}
