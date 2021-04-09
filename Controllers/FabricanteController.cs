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
    public class FabricanteController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessFabricante procFabricante = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public FabricanteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestFabricante ReqFabricante)
        {
            List<ResponseFabricante> ResponseWS = new();
            ResponseFabricante ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqFabricante.Nombre != null)
                {
                    var result = procFabricante.AddFabricante(ReqFabricante); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Fabricante not found");
                    }

                }
                else
                {
                    return NotFound("Fabricante not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Fabricante not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestFabricante> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseFabricante> ResponseWS = new();
            ResponseFabricante ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Fabricante not found");
                }
                else
                {
                    var result = procFabricante.FindFabricante(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Fabricante not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Fabricante not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Fabricante>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseFabricante> ResponseWS = new();
            ResponseFabricante ComplementoResponseWS = new();
           

            try
            {
                 List<Fabricante> result = procFabricante.FindAllFabricante();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Fabricante not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Fabricante not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestFabricante ReqFabricante)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseFabricante> ResponseWS = new();
            ResponseFabricante ComplementoResponseWS = new();
           


            try
            {
                 ResponseFabricante result = procFabricante.UpdateFabricante(ReqFabricante);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Fabricante not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Fabricante not found");
               
            }
         
        }




    }
}
