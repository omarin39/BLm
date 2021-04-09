using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using APIRest.Process;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace APIRest.Controllers
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
        public IdiomasController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestIdiomas ReqIdioma)
        {
            List<ResponseIdioma> ResponseWS = new();
            RequestIdiomas ComplementoResponseWS = new();
           
            try
            {
                if (ReqIdioma.Idioma1 != null)
                {
                    var result = ProcIdioma.AddIdioma(ReqIdioma);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Language not inserted");
                    }

                }
                else
                {
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
                    return NotFound("Cliente not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Cliente not found");

            }

        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestIdiomas ReqIdioma)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {

            try
            {
                ResponseIdioma result = ProcIdioma.UpdateIdioma(ReqIdioma);//Async();//.FindProcessLog(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Cliente not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Cliente not found");

            }

        }


    }
}
