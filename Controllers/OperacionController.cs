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
    public class OperacionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessOperacion procOperacion = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public OperacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestOperacion ReqOperacion)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqOperacion.Operacion != null)
                {
                    var result = procOperacion.AddOperacion(ReqOperacion); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                }
                else
                {
                    return NotFound("Operacion not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestOperacion> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Operacion not found");
                }
                else
                {
                    var result = procOperacion.FindOperacion(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Operacione>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
           

            try
            {
                 List<Operacione> result = procOperacion.FindAllOperacion();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestOperacion ReqOperacion)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseOperacion> ResponseWS = new();
            ResponseOperacion ComplementoResponseWS = new();
           


            try
            {
                 ResponseOperacion result = procOperacion.UpdateOperacion(ReqOperacion);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Operacion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Operacion not found");
               
            }
         
        }




    }
}
