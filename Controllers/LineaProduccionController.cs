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
    public class LineaProduccionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessLineaProduccion procLineaProduccion = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public LineaProduccionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestLineaProduccion reqLineaProduccion)
        {
            try
            {
                if (reqLineaProduccion.NombreLinea != null)
                {
                    var result = procLineaProduccion.AddLineaProduccion(reqLineaProduccion);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                }
                else
                {
                    return NotFound("LineaProduccion not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestLineaProduccion> Find(long IdLineaProduccionExt)
        {
            try
            {
                if (IdLineaProduccionExt >0)
                {
                    return NotFound("LineaProduccion not found");
                }
                else
                {
                    var result = procLineaProduccion.FindLineaProduccion(IdLineaProduccionExt);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<LineasProduccion>> FindAll()
        {
            try
            {
               
                List<LineasProduccion> result = procLineaProduccion.FindAllLineaProduccion();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestLineaProduccion ReqLineaProduccion)
        {
            try
            {
                ResponseGral result = procLineaProduccion.UpdateLineaProduccion(ReqLineaProduccion);
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
                    return NotFound("LineaProduccion not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");

            }

        }




    }
}
