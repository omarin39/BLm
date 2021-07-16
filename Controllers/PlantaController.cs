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
    public class PlantaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPlanta procPlanta = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PlantaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPlanta req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
              

                if (req.IdPlantaExterno != "0" && !String.IsNullOrEmpty(req.IdPlantaExterno) && !String.IsNullOrWhiteSpace(req.IdPlantaExterno))
                {
                    var result = procPlanta.AddPlanta(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Planta not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Planta not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Planta not found");
              
            }
         
        }





        [HttpGet("{IdPlantaExt}")]
        public ActionResult<RequestPlanta> Find(string IdPlantaExt)
        {
            try
            {
                if (!String.IsNullOrEmpty(IdPlantaExt) || !String.IsNullOrWhiteSpace(IdPlantaExt) || IdPlantaExt == "0")
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
        public ActionResult Put([FromBody] RequestPlanta req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procPlanta.UpdatePlanta(req, remoteIpAddress.ToString());
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
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Planta not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Planta not found");

            }

        }




    }
}
