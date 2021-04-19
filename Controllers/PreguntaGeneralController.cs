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
    public class PreguntaGeneralController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPreguntaGeneral procPreguntaGeneral = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PreguntaGeneralController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPreguntaGeneral reqPreguntaGeneral)
        {
            try
            {
                if (reqPreguntaGeneral.pregunta != null)
                {
                    var result = procPreguntaGeneral.AddPreguntaGeneral(reqPreguntaGeneral);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PreguntaGeneral not found");
                    }

                }
                else
                {
                    return NotFound("PreguntaGeneral not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");
              
            }
         
        }





        [HttpGet("{preguntaGeneral}")]
        public ActionResult<RequestPreguntaGeneral> Find(string preguntaGeneral)
        {
            try
            {
                if (preguntaGeneral == "")
                {
                    return NotFound("PreguntaGeneral not found");
                }
                else
                {
                    var result = procPreguntaGeneral.FindPreguntaGeneral(preguntaGeneral);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PreguntaGeneral not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<PreguntasPtGenerale>> FindAll()
        {
            try
            {
               
                List<PreguntasPtGenerale> result = procPreguntaGeneral.FindAllPreguntaGeneral();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PreguntaGeneral not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPreguntaGeneral ReqPreguntaGeneral)
        {
            try
            {
                ResponseGral result = procPreguntaGeneral.UpdatePreguntaGeneral(ReqPreguntaGeneral);
                if (result != null)
                {
                    return Ok(result);
                }
                else if (result.Codigo == "503")
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("PreguntaGeneral not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("PreguntaGeneral not found");

            }

        }




    }
}
