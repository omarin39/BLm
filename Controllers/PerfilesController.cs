﻿using APIRest.Common;
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
    public class PerfilesController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPerfil ProcPerfil = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PerfilesController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPerfiles ReqPerfil)
        {
            List<ResponsePerfiles> ResponseWS = new();
            ResponsePerfiles ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqPerfil.Perfil != null)
                {
                    var result = ProcPerfil.AddPerfil(ReqPerfil); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                }
                else
                {
                    return NotFound("Perfil not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPerfiles> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponsePerfiles> ResponseWS = new();
            ResponsePerfiles ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Perfil not found");
                }
                else
                {
                    var result = ProcPerfil.FindPerfil(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Perfile>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponsePerfiles> ResponseWS = new();
            ResponsePerfiles ComplementoResponseWS = new();
           

            try
            {
                 List<Perfile> result = ProcPerfil.FindAllPerfil();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestPerfiles ReqPerfil)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponsePerfiles> ResponseWS = new();
            ResponsePerfiles ComplementoResponseWS = new();
           


            try
            {
                 ResponsePerfiles result = ProcPerfil.UpdatePerfil(ReqPerfil);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
               
            }
         
        }




    }
}
