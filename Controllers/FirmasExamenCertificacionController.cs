using APIRestV2.Common;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using APIRestV2.Process;
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
    public class FirmasExamenCertificacionController : Controller
    {
        private JsonMediaTypeFormatter _formatter = new();
        private readonly ProcessFirmasExamenCertificacion ProcFirmasExamenCertifica = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();
        public FirmasExamenCertificacionController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestFirmasExamenCertificacion req)
        {
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

                if (req.IdExamenCertificacion > 0 )
                {
                    var result = ProcFirmasExamenCertifica.AddFirmasExamenCertificacion(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Empleado not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Empleado not found");
                }

            }
            catch (Exception e)
            {

                return NotFound(e.Message.ToString());

            }

        }


        [HttpGet("FindFirmasPendientes")]
        public ActionResult<ResponseFirmasPendientesExamenCertifica> FindFirmasPendientes()
        {
            try
            {
                List<ResponseFirmasPendientesExamenCertifica> result = ProcFirmasExamenCertifica.FindFirmasPendientes();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Fabricante not found");
                }
            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
            }
        }

    }
}
