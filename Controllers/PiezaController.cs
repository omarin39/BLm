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
    public class PiezaController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPieza procPieza = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PiezaController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.Nombre != null)
                {
                    var result = procPieza.AddPieza(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Pieza not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Pieza not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pieza not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPieza> Find(string Pieza) 
        {
            try
            {
                if (Pieza == "")
                {
                    return NotFound("Pieza not found");
                }
                else
                {
                    var result = procPieza.FindPieza(Pieza);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");
               
            }
         
        }

        [HttpGet("FindIdPieza/{idPieza}")]
        public ActionResult<RequestPieza> FindPorIdPieza(long idPieza)
        {
            try
            {
                if (idPieza <=0)
                {
                    return NotFound("Pieza not found");
                }
                else
                {
                    var result = procPieza.FindPiezaPorIdPieza(idPieza);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<VwPiezasMultimedia>> FindAll()
        {
            try
            {
               
                List<VwPiezasMultimedia> result = procPieza.FindAllPieza();
                if (result != null)
                    {
                    return result;
                    }
                    else
                    {
                        return NotFound("Pieza not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");
               
            }
         
        }

        [HttpGet("FindPiezaAutoComplete/{param}")]
        public ActionResult<List<ResponsePieza>> FindPiezaAutoComplete(String param)
        {
            try
            {

                List<ResponsePieza> result = procPieza.FindPiezaAutoComplete(param);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound("Pieza not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Pieza not found");

            }

        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPieza req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procPieza.UpdatePieza(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Pieza not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Pieza not found");

            }

        }




    }
}
