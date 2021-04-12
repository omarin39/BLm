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
    public class NaveController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessNave procNave = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public NaveController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestNave ReqNave)
        {
            try
            {
                if (ReqNave.nombre != null)
                {
                    var result = procNave.AddNave(ReqNave);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Nave not found");
                    }

                }
                else
                {
                    return NotFound("Nave not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Nave not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestNave> Find(string Nave)
        {
            try
            {
                if (Nave == "")
                {
                    return NotFound("Nave not found");
                }
                else
                {
                    var result = procNave.FindNave(Nave);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Nave not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Nave not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Nafe>> FindAll()
        {
            try
            {
               
                List<Nafe> result = procNave.FindAllNave();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Nave not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Nave not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestNave ReqNave)
        {
            try
            {
                ResponseGral result = procNave.UpdateNave(ReqNave);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Nave not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Nave not found");

            }

        }




    }
}
