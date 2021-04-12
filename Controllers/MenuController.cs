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
        public MenuController(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RequestMenu ReqMenu)
        {
            try
            {
                if (!string.IsNullOrEmpty(ReqMenu.NombreMenu))
                {
                    var result = procMenu.AddMenu(ReqMenu);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Menu not inserted");
                    }

                }
                else
                {
                    return NotFound("Menu required");
                }

            }
            catch (Exception e)
            {
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
        public ActionResult Put([FromBody] RequestMenu ReqMenu)
        {
            try
            {
                ResponseGral result = procMenu.UpdateMenu(ReqMenu);
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
    }
}
