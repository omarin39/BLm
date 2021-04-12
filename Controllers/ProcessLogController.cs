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
    public class ProcessLogController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessProcessLog ProcLOG = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public ProcessLogController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqProcessLog.Data != null)
                {
                    var result = ProcLOG.AddProcessLog(ReqProcessLog); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

                }
                else
                {
                    return NotFound("Process Log not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestProcessLog> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Process Log not found");
                }
                else
                {
                    var result = ProcLOG.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<ProcessLog>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();
           

            try
            {
                 List<ProcessLog> result = ProcLOG.FindAllProcessLog();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
               
            }
         
        }
        [HttpPut()]
        public ActionResult Put([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                ResponseGral result = ProcLOG.UpdateProcessLog(ReqProcessLog);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Process Log not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");

            }

        }


    }
}
