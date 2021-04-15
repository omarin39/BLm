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
    public class EmpleadoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessEmpleado ProcEmpleado = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public EmpleadoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestEmpleado ReqEmpleado)
        {
            try
            {
                if (ReqEmpleado.Nombre != null)
                {
                    var result = ProcEmpleado.AddEmpleado(ReqEmpleado); 
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                }
                else
                {
                    return NotFound("Empleado not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestEmpleado> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Empleado not found");
                }
                else
                {
                    var result = ProcEmpleado.FindEmpleado(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Empleado>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                 List<Empleado> result = ProcEmpleado.FindAllEmpleado();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestEmpleado ReqEmpleado)
        //public ActionResult<ProcessLog> Update() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                 ResponseGral result = ProcEmpleado.UpdateEmpleado(ReqEmpleado);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Empleado not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Empleado not found");
               
            }
         
        }




    }
}
