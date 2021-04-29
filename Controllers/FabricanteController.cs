using APIRest.Common;
using APIRest.Controllers.Process;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private ProcessFabricante procFabricante = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();
        public FabricanteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }
        [HttpPost]
        public ActionResult Post([FromBody] RequestFabricante req)
        {
            try
            {
                var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

                if (req.Nombre != null)
                {
                    var result = procFabricante.AddFabricante(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Fabricante not found");
                    }
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
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
        public ActionResult<List<Fabricante>> FindAll()
        {
            try
            {
                 List<Fabricante> result = procFabricante.FindAllFabricante();
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
        public ActionResult Put([FromBody] RequestFabricante req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               
                ResponseGral result = procFabricante.UpdateFabricante(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("Fabricante not found");
                    }

                
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Fabricante not found");
               
            }
         
        }
    }
}
