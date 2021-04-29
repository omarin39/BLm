using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.Helpers;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Threading.Tasks;


namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessUSR ProcUSR = new();
        private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public UsersController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<RequestUsers> req)
        {
            List<ResponseUsers> ResponseWS = new();
            ResponseUsers ComplementoResponseWS = new();
            ComplementosFailResponse failWS = new();
            ComplementosSuccessResponse SuccWS = new();
            ComplementoResponseWS.Mal = new();
            ComplementoResponseWS.Bien = new();
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            try
            {
                if (req[0].User != null)
                {
                    var result = await ProcUSR.ProcesaUSER(req, Configuration, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Role not found");
                    }

                }
                else
                {
                    failWS.Codigo = Configuration.GetSection("CodeErrorValid").GetSection("erro800").Value;
                    failWS.Mensaje = Configuration.GetSection("CodeErrorValid").GetSection("erro800msn").Value;
                    failWS.Operacion = "Null";
                    failWS.NoNomina = "0";

                    ComplementoResponseWS.Mal.Add(failWS);
                    ComplementoResponseWS.Codigo = 200;
                    ResponseWS.Add(ComplementoResponseWS);
                }
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                failWS.Codigo = "801";
                failWS.Mensaje = "Error: " + e.Message;
                failWS.Operacion = "Null";
                failWS.NoNomina = "0";

                ComplementoResponseWS.Mal.Add(failWS);
                ComplementoResponseWS.Codigo = 200;

                ResponseWS.Add(ComplementoResponseWS);
            }
            return Ok(ResponseWS); 
        }
    }
}
