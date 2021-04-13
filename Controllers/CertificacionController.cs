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
    public class CertificacionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessCertificacion procCertificacion = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public CertificacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestCertificacion ReqCertificacion)
        {
            try
            {
                if (ReqCertificacion.fechaEntrenamiento != null)
                {
                    var result = procCertificacion.AddCertificacion(ReqCertificacion);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Certificacion not found");
                    }

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





        [HttpGet("{id}")]
        public ActionResult<RequestCertificacion> Find(long idCertificacion)
        {
            try
            {
                if (idCertificacion < 0)
                {
                    return NotFound("Certificacion not found");
                }
                else
                {
                    var result = procCertificacion.FindCertificacion(idCertificacion);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Certificacion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Certificacion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Certificacione>> FindAll()
        {
            try
            {
               
                List<Certificacione> result = procCertificacion.FindAllCertificacion();
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




        [HttpPut()]
        public ActionResult Put([FromBody] RequestCertificacion ReqCertificacion)
        {
            try
            {
                ResponseGral result = procCertificacion.UpdateCertificacion(ReqCertificacion);
                if (result != null)
                {
                    return Ok(result);
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
