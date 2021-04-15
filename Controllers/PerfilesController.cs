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
    public class PerfilesController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPerfil ProcPerfil = new();
       // private ValidaDatosRequest _validaReq = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        


        public PerfilesController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPerfiles ReqPerfil)
        {
            try
            {
                if (ReqPerfil.Perfil != null)
                {
                    var result = ProcPerfil.AddPerfil(ReqPerfil);
                    if (result != null)
                    {
                        ProcessOperacion ProOper = new();
                        ProcessPerfilOperacionPermiso insPer = new();
                        List<RequestPerfilOperacionPermisoItem> _Lstpermiso = new();
                        List<Operacione> LstOper = ProOper.FindAllOperacion();
                        foreach (var item in LstOper)
                        {
                            RequestPerfilOperacionPermisoItem _permiso = new();
                            _permiso.IdOpercion = item.Id;
                            _permiso.IdPerfil = result.Id;
                            _permiso.Crear = false;
                            _permiso.Ver = false;
                            _permiso.Eliminar = false;
                            _permiso.Editar = false;
                            _Lstpermiso.Add(_permiso);
                        }
                        insPer.AddPerfilOperacionPermisoList(_Lstpermiso);
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                }
                else
                {
                    return NotFound("Perfil not found");
                }
               
            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
              
            }
         
        }





        [HttpGet("{id}")]
        public ActionResult<RequestPerfiles> Find(long id) //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Perfil not found");
                }
                else
                {
                    var result = ProcPerfil.FindPerfil(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                }

            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
               
            }
         
        }


        [HttpGet()]
        public ActionResult<List<Perfile>> FindAll() //ActionResult Get([FromBody] RequestProcessLog ReqProcessLog)
        {
            try
            {
                //List<Perfile> result = ProcPerfil.FindAllPerfil().Where(v=>v.Activo==true).ToList();//Async();//.FindProcessLog(id);
                List<Perfile> result = ProcPerfil.FindAllPerfil();//Async();//.FindProcessLog(id);
                if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound("Perfil not found");
                    }

                
            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");
               
            }
         
        }




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPerfiles ReqPerfil)
        {
            try
            {
                ResponseGral result = ProcPerfil.UpdatePerfil(ReqPerfil);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Perfil not found");
                }


            }
            catch (Exception e)
            {
                return NotFound("Perfil not found");

            }

        }




    }
}
