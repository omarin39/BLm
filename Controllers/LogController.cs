using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;


namespace APIRestV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private Process_Log procLog = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public LogController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestLog ReqLog)
        {
            try
            {
                if (ReqLog.Data != null)
                {
                    var result = procLog.AddLog(ReqLog);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Log not found");
                    }

                }
                else
                {
                    return NotFound("Log not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Log not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<ResponseProcessLogDate> Find(long id)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound("Log not found");
                }
                else
                {
                    var result = procLog.FindLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Log not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Log not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<ResponseProcessLogDate>> FindAll()
        {
            try
            {
               
                List<ResponseProcessLogDate> result = procLog.FindAllLog();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Log not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Log not found");
               
            }
         
        }




    }
}
