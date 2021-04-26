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
    public class PlantaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPlanta procPlanta = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PlantaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPlanta ReqPlanta)
        {
            try
            {
                if (ReqPlanta.IdPlantaExt != null)
                {
                    var result = procPlanta.AddPlanta(ReqPlanta);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Planta not found");
                    }

                }
                else
                {
                    return NotFound("Planta not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Planta not found");
              
            }
         
        }





        [HttpGet("{IdPlantaExt}")]
        public ActionResult<RequestPlanta> Find(long IdPlantaExt)
        {
            try
            {
                if (IdPlantaExt < 0)
                {
                    return NotFound("Planta not found");
                }
                else
                {
                    var result = procPlanta.FindPlanta(IdPlantaExt);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Planta not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Planta not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<ResponsePlanta>> FindAll()
        {
            try
            {
               
                List<ResponsePlanta> result = procPlanta.FindAllPlanta();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Planta not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Planta not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPlanta ReqPlanta)
        {
            try
            {
                ResponseGral result = procPlanta.UpdatePlanta(ReqPlanta);
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
                    return NotFound("Planta not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Planta not found");

            }

        }




    }
}
