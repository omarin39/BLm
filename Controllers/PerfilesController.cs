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
    public class PerfilesController : ControllerBase
    {
        private JsonMediaTypeFormatter _formatter = new();
        private ProcessPerfil ProcPerfil = new();
        public static IConfiguration Configuration { get; set; }
        public static UsrKey paramUsrValida = new();
        private Controllers.Process.Process_Log procLog = new Controllers.Process.Process_Log();


        public PerfilesController(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
        }


        [HttpPost]
        public ActionResult Post([FromBody] RequestPerfiles req,string ip)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                

                if (req.Perfil1 != null)
                {
                    var result = ProcPerfil.AddPerfil(req, remoteIpAddress.ToString());
                    if (result.Codigo == "200")
                    {
                        ProcessOperacion ProOper = new();
                        ProcessPerfilOperacionPermiso insPer = new();
                        List<RequestPerfilOperacionPermisoItem> _Lstpermiso = new();
                        List<Operacion> LstOper = ProOper.FindAllOperacion();
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
                        insPer.AddPerfilOperacionPermisoList(_Lstpermiso, ip);
                        return Ok(result);
                    }else if (result.Codigo == "-1")
                    {
                        return Ok(result);
                    }
                    else
                    {
                        procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                        return NotFound("Perfil not found");
                    }

                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Parametros erroneos", 400);
                    return NotFound("Perfil not found");
                }
               
            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
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
        public ActionResult<List<Perfil>> FindAll() 
        {
            try
            {
                //List<Perfile> result = ProcPerfil.FindAllPerfil().Where(v=>v.Activo==true).ToList();//Async();//.FindProcessLog(id);
                List<Perfil> result = ProcPerfil.FindAllPerfil();
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




        [HttpPut()]
        public ActionResult Put([FromBody] RequestPerfiles req)
        {
            var remoteIpAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            try
            {
                

                ResponseGral result = ProcPerfil.UpdatePerfil(req, remoteIpAddress.ToString());

                if (result.Codigo == "200")
                {
                    return Ok(result);
                }
                else if (result.Codigo == "501" || result.Codigo == "502" || result.Codigo == "503" || result.Codigo == "-1")
                {
                    return Ok(result);
                }
                else
                {
                    procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), "Error al realizar la operación", 401);
                    return NotFound("Perfil not found");
                }


            }
            catch (Exception e)
            {
                procLog.AddLog(remoteIpAddress.ToString(), procLog.GetPropertyValues(req, System.Reflection.MethodBase.GetCurrentMethod().Name), e.InnerException.Message, 400);
                return NotFound("Perfil not found");

            }

        }




    }
}
