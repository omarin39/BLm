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
    public class WorkflowController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessWorkflow workflow = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();

        public WorkflowController(IConfiguration configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestWorkflow req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {


                if (req.PiezaIdPieza != null)
                {
                    var result = workflow.AddWorkflow(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Workflow not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Workflow not found");
                }

            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Workflow not found");

            }

        }

        [HttpPut()]
        public ActionResult Put([FromBody] RequestWorkflow req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {

                ResponseGral result = workflow.UpdateWorkflow(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Workflow not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Workflow not found");

            }

        }

        [HttpPut("Orden")]
        public ActionResult Put([FromBody] List<RequestWorkflow> wfs)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            RequestWorkflow req=null;
            try
            {
                ResponseGral result = null;
                
                foreach (var item in wfs)
                {
                    req = item;
                    result = workflow.UpdateWorkflow(item, remoteIpAddress.ToString());

                    if (result == null)
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Workflow not found");
                    }
                }
                
                return Ok(result);
                


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Workflow not found");

            }

        }

        [HttpGet("{id}")]
        public ActionResult<Workflow> Find(long id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Workflow not found");
                }
                else
                {
                    var result = workflow.FindWorflowById(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Workflow not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Workflow not found");

            }

        }

        [HttpGet("FindWorkflowPieza/{Pieza}")]
        public ActionResult<List<RequestWorkflow>> FindWorkflow(long Pieza)
        {
            try
            {

                if (Pieza <= 0)
                {
                    return NotFound("Workflow not found");
                }
                else
                {
                    var result = workflow.FindWorkflowByPieza(Pieza);
                    return Ok(result);

                }

            }
            catch (Exception e)
            {
                return NotFound("Workflow not found");

            }

        }
    }
}
