using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using NWebsec.AspNetCore.Core.Web;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        


        public UsersController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<RequestUsers> ReqUser)
        {
            List<ResponseUsers> ResponseWS = new();
            ResponseUsers ComplementoResponseWS = new();
            ComplementosFailResponse failWS = new();
            ComplementosSuccessResponse SuccWS = new();
            ComplementoResponseWS.Mal = new();
            ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqUser[0].User != null)
                {
                    var result = await ProcUSR.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
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
