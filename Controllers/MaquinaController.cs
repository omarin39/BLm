using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models;
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
    public class MaquinaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessMaquina process = new();

        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public MaquinaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.Nombre != null)
                {
                    var result = process.AddMaquina(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Maquina not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Maquina not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Maquina not found");
              
            }
         
        }


        [HttpPut()]
        public ActionResult Put([FromBody] RequestMaquina req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = process.UpdateMaquina(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Pregunta not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pregunta not found");

            }

        }


        [HttpGet("{id}")]
        public ActionResult<VwMaquinaPregunta> Find(long id) 
        {
            try
            {
                if (id <=0)
                {
                    return NotFound("Maquina not found");
                }
                else
                {
                    var result = process.findMaquinaPorId(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Maquina not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Maquina not found");
               
            }
         
        }

        [HttpGet()]
        public ActionResult<List<VwMaquinaPregunta>> FindAll()
        {
            try
            {

                List<VwMaquinaPregunta> result = process.FindAllMaquina();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Maquina not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Maquina not found");

            }

        }


        [HttpGet("FindMaquinasByPlanta/{planta}")]
        public ActionResult<List<Maquina>> FindByPlanta(long planta)
        {
            try
            {
               
                List<Maquina> result = process.FindMaquinasByPlanta(planta);
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Maquinas not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Maquinas not found");
               
            }
         
        }

        [HttpGet("FindMaquinasByPlantaNave/{planta}/{nave}")]
        public ActionResult<List<Maquina>> FindByPlantaNave(long planta, long nave)
        {
            try
            {

                List<Maquina> result = process.FindMaquinasByPlantaNave(planta,nave);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Maquinas not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Maquinas not found");

            }

        }





    }
}
