using APIRest.Common;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using APIRest.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private ProcessMenu procMenu= new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public MenuController(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestMenu req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (!string.IsNullOrEmpty(req.NombreMenu))
                {
                    var result = procMenu.AddMenu(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("Menu not inserted");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Menu required");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Menu not found");

            }

        }
        [HttpGet("{id}")]
        public ActionResult<RequestMenu> Find(long id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Menu not found");
                }
                else
                {
                    var result = procMenu.FindMenu(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Menu not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Menu not found");

            }

        }
        [HttpGet()]
        public ActionResult<List<Menu>> FindAll()
        {
            try
            {
                List<Menu> result = procMenu.FindAllMenu();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Menu not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Menu not found");

            }

        }
        [HttpPut()]
        public ActionResult Put([FromBody] RequestMenu req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
              

                ResponseGral result = procMenu.UpdateMenu(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("Menu not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("Menu not found");

            }

        }
    }
}
