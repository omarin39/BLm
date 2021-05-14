using APIRestV2.Common;
using APIRestV2.Controllers.Process;
using APIRestV2.Models;
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
    public class ProcessLogController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessProcessLog ProcLOG = new();
       
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public ProcessLogController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();

            try
            {
             
              
                if (ReqProcessLog.Data != null)
                {
                    var result = ProcLOG.AddProcessLog(ReqProcessLog);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                       // procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Process Log not found");
                    }

                }
                else
                {
                    return NotFound("Process Log not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
              
            }
         
        }

        [HttpGet("{id}")]
        public ActionResult<RequestProcessLog> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();
           

            try
            {
                if (id == 0)
                {
                    return NotFound("Process Log not found");
                }
                else
                {
                    var result = ProcLOG.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
               
            }
         
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<List<ProcessLog>> FindByDate([FromBody] RequestProcessLogByDate fechas)
        {
            //format dates 2010-01-21
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();

      
            bool bCaso1 = false;
            bool bCaso2 = false;

            if (fechas.fechaIni == DateTime.MinValue) { bCaso1 = true; }
            if (fechas.fechaFin == DateTime.MinValue) { bCaso2 = true; }

            try
            {
               
                    List<ProcessLog> result = null;
                    if (bCaso1 && bCaso2)
                    {
                        //sin fechas, trae todo
                        result = ProcLOG.FindAllProcessLog();
                    }
                    else if (!bCaso1 && !bCaso2)
                    {
                        if (fechas.fechaFin < fechas.fechaIni)
                        {
                            return NotFound("La fecha fin no puede ser menor que la fecha inicial");
                        }
                        else
                        {
                            //trae basado en los parametros de fechaini y fechafin
                            result = ProcLOG.FindByFechas(fechas.fechaIni, fechas.fechaFin);
                        }
                    }
                    else if (bCaso1 && !bCaso2)
                    {
                        //trae todo menor a fecha fin
                        result = ProcLOG.FindByfechaFin(fechas.fechaFin);
                    }
                    else if (!bCaso1 && bCaso2)
                    {
                        //trae todo mayor a fecha ini
                        result = ProcLOG.FindByFechaIni(fechas.fechaIni);
                    }
                    else
                    {
                    //trae basado en los parametros de fechaini y fechafin
                        if (fechas.fechaFin < fechas.fechaIni)
                        {
                            return NotFound("La fecha fin no puede ser menor que la fecha inicial");
                        }
                        else
                        {
                            //trae basado en los parametros de fechaini y fechafin
                            result = ProcLOG.FindByFechas(fechas.fechaIni, fechas.fechaFin);
                        }
                    }


                    
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

           

            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");

            }

        }
       

        [HttpGet()]
        public ActionResult<List<ProcessLog>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            List<ResponseProcessLog> ResponseWS = new();
            ResponseProcessLog ComplementoResponseWS = new();
           

            try
            {
                 List<ProcessLog> result = ProcLOG.FindAllProcessLog();//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Process Log not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");
               
            }
         
        }
      
        [HttpPut()]
        public ActionResult Put([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
               
                ResponseGral result = ProcLOG.UpdateProcessLog(ReqProcessLog);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                   // procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Process Log not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Process Log not found");

            }

        }


    }
}
