using APIRestV2.Controllers.Process;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using APIRestV2.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionNivelesCertificacionController : ControllerBase
    {
        public static IConfiguration Configuration { get; set; }
        public ProcessConfiguracionNivelesCertificacion ProcConfigNivelCertifica = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public ConfiguracionNivelesCertificacionController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public ActionResult<List<ResponseConfiguracionNivelesCertificacion>> FindAll()
        {
            try
            {
                 List<ResponseConfiguracionNivelesCertificacion> result = ProcConfigNivelCertifica.FindAllConfiguracionNivelesCertificacion();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }

        [HttpGet("{Id}")]
        public ActionResult<ResponseConfiguracionNivelesCertificacion> FindById(long Id)
        {
            try
            {
                ResponseConfiguracionNivelesCertificacion result = ProcConfigNivelCertifica.FindById(Id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("NivelesCertificacion not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");

            }

        }

        [HttpGet("FindByIdNivelCertifica/{IdNivelCertifica}")]
        public ActionResult<ResponseConfiguracionNivelesCertificacion> FindByIdNivelCertifica(long IdNivelCertifica)
        {
            try
            {
                ResponseConfiguracionNivelesCertificacion result = ProcConfigNivelCertifica.FindByIdNivelCertifica(IdNivelCertifica);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("NivelesCertificacion not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");

            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestConfiguracionNivelesCertificacion _Req)
        {
            var RemoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                if (_Req.IdNivelCertificacion > 0)
                {
                    var result = ProcConfigNivelCertifica.AddConfiguraNivelesCertificacion(_Req, RemoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(RemoteIpAddress.ToString(), procLog.GetPropertyValues(_Req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("NivelesCertificacion not found");
                    }

                }
                else
                {
                    procLog.AddLog(RemoteIpAddress.ToString(), procLog.GetPropertyValues(_Req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("ConfigurationNivelesCertificacion not found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestConfiguracionNivelesCertificacion _Req)
        {
            var RemoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                ResponseGral result = ProcConfigNivelCertifica.UpdateConfiguraNivelesCertificacion(_Req, RemoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(RemoteIpAddress.ToString(), procLog.GetPropertyValues(_Req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("NivelesCertificacion not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(RemoteIpAddress.ToString(), procLog.GetPropertyValues(_Req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("NivelesCertificacion not found");

            }

        }
    }
}
