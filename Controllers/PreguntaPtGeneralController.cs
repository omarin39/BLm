using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
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
    public class PreguntaPtGeneralController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaPtGeneral procPreguntaPtGeneral = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PreguntaPtGeneralController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaPtGeneral ReqPregunta)
        {
            try
            {
                if (ReqPregunta.pregunta != null)
                {
                    var result = procPreguntaPtGeneral.AddPregunta(ReqPregunta);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pregunta not found");
                    }

                }
                else
                {
                    return NotFound("Pregunta not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPreguntaPtGeneral> Find(string Pregunta)
        {
            try
            {
                if (Pregunta == "")
                {
                    return NotFound("Pregunta not found");
                }
                else
                {
                    var result = procPreguntaPtGeneral.FindPregunta(Pregunta);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pregunta not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<PreguntasPtGenerale>> FindAll()
        {
            try
            {
               
                List<PreguntasPtGenerale> result = procPreguntaPtGeneral.FindAllPregunta();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Pregunta not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaPtGeneral ReqPregunta)
        {
            try
            {
                ResponseGral result = procPreguntaPtGeneral.UpdatePregunta(ReqPregunta);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Pregunta not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pregunta not found");

            }

        }




    }
}
