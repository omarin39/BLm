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
    public class NivelesCertificacionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessNivelesCertificacion procNivelesCertificacion = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public NivelesCertificacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestNivelesCertificacion ReqNivelesCertificacion)
        {
            List<ResponseNivelesCertificacion> ResponseWS = new();
            ResponseNivelesCertificacion ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqNivelesCertificacion.desc_nivel_certificacion != null)
                {
                    var result = procNivelesCertificacion.AddNivelesCertificacion(ReqNivelesCertificacion); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                }
                else
                {
                    return NotFound("NivelesCertificacion not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestNivelesCertificacion> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseNivelesCertificacion> ResponseWS = new();
            ResponseNivelesCertificacion ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("NivelesCertificacion not found");
                }
                else
                {
                    var result = procNivelesCertificacion.FindNivelesCertificacion(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<NivelesCertificacion>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseNivelesCertificacion> ResponseWS = new();
            ResponseNivelesCertificacion ComplementoResponseWS = new();
           

            try
            {
                 List<NivelesCertificacion> result = procNivelesCertificacion.FindAllNivelesCertificacion();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestNivelesCertificacion ReqNivelesCertificacion)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                ResponseGral result = procNivelesCertificacion.UpdateNivelesCertificacion(ReqNivelesCertificacion);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("NivelesCertificacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("NivelesCertificacion not found");
               
            }
         
        }




    }
}
