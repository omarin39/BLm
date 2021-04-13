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
    public class PerfilOperacionPermisoController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPerfilOperacionPermiso procPerfilOperacionPermiso = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PerfilOperacionPermisoController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPerfilOperacionPermiso ReqPerfilOperacionPermiso)
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
            //ComplementosFailResponse failWS = new();
            //ComplementosSuccessResponse SuccWS = new();
            //ComplementoResponseWS.Mal = new();
            //ComplementoResponseWS.Bien = new();

            try
            {
                if (ReqPerfilOperacionPermiso.IdPerfil != null)
                {
                    var result = procPerfilOperacionPermiso.AddPerfilOperacionPermiso(ReqPerfilOperacionPermiso); //.ProcesaUSER(ReqUser, Configuration);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }
                else
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
              
            }
         
        }


        [HttpPost("PostPerfilOperacionPermiso")]
        public ActionResult Post([FromBody] List<RequestPerfilOperacionPermisoItem> reqPerfilOperacionPermisoList)
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
    

            try
            {
                if (reqPerfilOperacionPermisoList.Count > 0)
                {
                    var result = procPerfilOperacionPermiso.AddPerfilOperacionPermisoList(reqPerfilOperacionPermisoList);
                    return Ok(result);

                }
                else
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }

            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");

            }

        }





        [HttpGet("{id}")]
        public ActionResult<RequestPerfilOperacionPermiso> Find(long idPerfil) //idPerfil
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
           

            try
            {
                if (idPerfil <= 0)
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }
                else
                {
                    var result = procPerfilOperacionPermiso.FindPerfilOperacionPermiso(idPerfil);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
               
            }
         
        }


       
        [HttpGet("FindPorPerfil/{idPerfil}")]
        public ActionResult<List<ResponsePerfilOperacionPermisoJoined>> FindPorPerfil(long idPerfil) 
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();


            try
            {
                if (idPerfil <= 0)
                {
                    return NotFound("PerfilOperacionPermiso not found");
                }
                else
                {
                    var result = procPerfilOperacionPermiso.FindPerfilOperacionPermisoJoined(idPerfil);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");

            }

        }


        [HttpGet()]
        public ActionResult<List<PerfilOperacionPermiso>> FindAll() 
        {
            List<ResponsePerfilOperacionPermiso> ResponseWS = new();
            ResponsePerfilOperacionPermiso ComplementoResponseWS = new();
           

            try
            {
                 List<PerfilOperacionPermiso> result = procPerfilOperacionPermiso.FindAllPerfilOperacionPermiso();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
               
            }
         
        }




        [HttpPut()]
         public ActionResult Put([FromBody] RequestPerfilOperacionPermiso ReqPerfilOperacionPermiso)
        {
            try
            {
                ResponseGral result = procPerfilOperacionPermiso.UpdatePerfilOperacionPermiso(ReqPerfilOperacionPermiso);//Async();//.FindProcessLog(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("PerfilOperacionPermiso not found");
                    }
            }
            catch (Exception e)
            {
                return NotFound("PerfilOperacionPermiso not found");
            }
        }
    }
}
