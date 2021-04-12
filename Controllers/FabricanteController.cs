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
        public FabricanteController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }
        [HttpPost]
        public ActionResult Post([FromBody] RequestFabricante ReqFabricante)
        {
            try
            {
                if (ReqFabricante.Nombre != null)
                {
                    var result = procFabricante.AddFabricante(ReqFabricante);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Fabricante not found");
                    }
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
        public ActionResult Put([FromBody] RequestFabricante ReqFabricante)
        {
            try
            {
                 ResponseGral result = procFabricante.UpdateFabricante(ReqFabricante);
                    if (result != null)
                    {
                        return Ok(result);
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
    }
}
