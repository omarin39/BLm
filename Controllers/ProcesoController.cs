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
    public class ProcesoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessProceso procProceso = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public ProcesoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestProceso ReqProceso)
        {
            try
            {
                if (ReqProceso.nombre != null)
                {
                    var result = procProceso.AddProceso(ReqProceso);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Proceso not found");
                    }

                }
                else
                {
                    return NotFound("Proceso not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Proceso not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestProceso> Find(string Proceso)
        {
            try
            {
                if (Proceso == "")
                {
                    return NotFound("Proceso not found");
                }
                else
                {
                    var result = procProceso.FindProceso(Proceso);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Proceso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Proceso not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Proceso>> FindAll()
        {
            try
            {
               
                List<Proceso> result = procProceso.FindAllProceso();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Proceso not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Proceso not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestProceso ReqProceso)
        {
            try
            {
                ResponseGral result = procProceso.UpdateProceso(ReqProceso);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Proceso not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Proceso not found");

            }

        }




    }
}
