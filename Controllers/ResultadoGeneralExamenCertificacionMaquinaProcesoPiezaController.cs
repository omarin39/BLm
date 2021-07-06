using APIRestV2.Common;
using APIRestV2.Models;
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
    public class ResultadoGeneralExamenCertificacionMaquinaProcesoPiezaController : Controller
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessResultadoGeneralExamenCertificacionMaquinaProcesoPieza ProcResGral = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public ResultadoGeneralExamenCertificacionMaquinaProcesoPiezaController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpGet("FindResultadoGralExamenCertifica/{IdExamenCertificacion}/{TipoPregunta}/{IdIdioma}")]
        public ActionResult<List<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza>> FindResultadoGralExamenCertifica(long IdExamenCertificacion, long TipoPregunta, long IdIdioma)
        {
            try
            {

                List<ResultadoGeneralExamenCertificacionMaquinaProcesoPieza> result = ProcResGral.FindResultadoGralExamenCertifica(IdExamenCertificacion,TipoPregunta,IdIdioma);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Certificacion not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Certificacion not found");

            }

        }
    }
}
