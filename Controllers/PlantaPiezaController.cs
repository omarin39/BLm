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
    public class PiezaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPieza procPieza = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PiezaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPieza ReqPieza)
        {
            try
            {
                if (ReqPieza.nombre != null)
                {
                    var result = procPieza.AddPieza(ReqPieza);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                }
                else
                {
                    return NotFound("Pieza not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPieza> Find(string Pieza) 
        {
            try
            {
                if (Pieza == "")
                {
                    return NotFound("Pieza not found");
                }
                else
                {
                    var result = procPieza.FindPieza(Pieza);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Pieza>> FindAll()
        {
            try
            {
               
                List<Pieza> result = procPieza.FindAllPieza();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPieza ReqPieza)
        {
            try
            {
                ResponseGral result = procPieza.UpdatePieza(ReqPieza);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Pieza not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");

            }

        }




    }
}
