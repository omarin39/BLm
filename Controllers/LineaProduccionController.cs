﻿using APIRest.Common;
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
    public class LineaProduccionController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessLineaProduccion procLineaProduccion = new();
      
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public LineaProduccionController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestLineaProduccion req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
               

                if (req.NombreLinea != null)
                {
                    var result = procLineaProduccion.AddLineaProduccion(req, remoteIpAddress.ToString());
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                        return NotFound("LineaProduccion not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("LineaProduccion not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("LineaProduccion not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestLineaProduccion> Find(long IdLineaProduccionExt)
        {
            try
            {
                if (IdLineaProduccionExt <= 0)
                {
                    return NotFound("LineaProduccion not found");
                }
                else
                {
                    var result = procLineaProduccion.FindLineaProduccion(IdLineaProduccionExt);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");
               
            }
         
        }

        [HttpGet("{idNave}")]
        public ActionResult<RequestLineaProduccion> FindLineaProduccionNave(long IdLineaProduccionExt)
        {
            try
            {
                if (IdLineaProduccionExt <= 0)
                {
                    return NotFound("LineaProduccion not found");
                }
                else
                {
                    var result = procLineaProduccion.FindLineaProduccionNave(IdLineaProduccionExt);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<LineasProduccion>> FindAll()
        {
            try
            {
               
                List<LineasProduccion> result = procLineaProduccion.FindAllLineaProduccion();
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("LineaProduccion not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("LineaProduccion not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestLineaProduccion req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                

                ResponseGral result = procLineaProduccion.UpdateLineaProduccion(req, remoteIpAddress.ToString());
                if (result != null)
                {
                    return Ok(result);
                }
                else if (result.Codigo == "503")
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al contactar el server", 401);
                    return NotFound("LineaProduccion not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.Message, 400);
                return NotFound("LineaProduccion not found");

            }

        }




    }
}
