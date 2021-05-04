using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;


namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaveController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessNave procNave = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public NaveController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestNave req)
        {

            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                if (req.nombre != null)
                {
                    var result = procNave.AddNave(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Nave not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Nave not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Nave not found");
              
            }
         
        }





        [HttpGet("{Nave}")]
        public ActionResult<RequestNave> Find(long IdNave)
        {
            try
            {
                if (IdNave == 0)
                {
                    return NotFound("Nave not found");
                }
                else
                {
                    var result = procNave.FindNave(IdNave);
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
        [HttpGet("FindNavePlanta/{Planta}")]
        public ActionResult<List<RequestNave>> FindNavePlanta(string Planta)
        {
            try
            {
              
                if (Planta == "")
                {
                    return NotFound("Nave not found");
                }
                else
                {
                    var result = procNave.FindNavePlanta(Planta);
                    return Ok(result);

                }

            }
            catch (Exception e)
            {
                return NotFound("Nave not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<ResponseNave>> FindAll()
        {
            try
            {
                
                List<ResponseNave> result = procNave.FindAllNave();
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
        public ActionResult Put([FromBody] RequestNave req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                ResponseGral result = procNave.UpdateNave(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("Nave not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Nave not found");

            }

        }




    }
}
