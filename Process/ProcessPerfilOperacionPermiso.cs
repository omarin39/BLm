using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessPerfilOperacionPermiso
    {       
        public DataPerfilOperacionPermiso PerfilOperacionPermisoData = new();
        public ResponseGral AddPerfilOperacionPermiso(RequestPerfilOperacionPermiso PerfilOperacionPermiso, String ip)
        {
            ResponseGral respAltaPerfilOperacionPermiso = new();
            try
            {
                PerfilOperacionPermiso logNewRegistro = new();
                logNewRegistro.IdPerfil = PerfilOperacionPermiso.IdPerfil;
                logNewRegistro.IdOperacion = PerfilOperacionPermiso.IdOperacion;
                logNewRegistro.Crear = PerfilOperacionPermiso.Crear;
                logNewRegistro.Editar = PerfilOperacionPermiso.Editar;
                logNewRegistro.Eliminar = PerfilOperacionPermiso.Eliminar;
                logNewRegistro.Ver = PerfilOperacionPermiso.Ver;
                long respNewUSR = PerfilOperacionPermisoData.AddPerfilOperacionPermiso(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPerfilOperacionPermiso.Id = respNewUSR;
                    respAltaPerfilOperacionPermiso.Codigo = "200";
                    respAltaPerfilOperacionPermiso.Mensaje = "OK";
                    return respAltaPerfilOperacionPermiso;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResponseGral UpdatePerfilOperacionPermiso(RequestPerfilOperacionPermiso perfilOperacionPermiso, String ip)
        {
            ResponseGral respAltaPerfilOperacionPermiso = new();



            var PerfilOperacionPermisoBuscado = FindPerfilOperacionPermiso(perfilOperacionPermiso.Id);

            if (PerfilOperacionPermisoBuscado == null)
            {
                return respAltaPerfilOperacionPermiso;
            }
            else if (PerfilOperacionPermisoBuscado.Id == -1)
            {
                respAltaPerfilOperacionPermiso.Id = perfilOperacionPermiso.Id;
                respAltaPerfilOperacionPermiso.Codigo = "400";
                respAltaPerfilOperacionPermiso.Mensaje = "Not found";
                return respAltaPerfilOperacionPermiso;
            }
            else
            {
                try
                {
                    PerfilOperacionPermisoBuscado.IdPerfil = perfilOperacionPermiso.IdPerfil;
                    PerfilOperacionPermisoBuscado.IdOperacion = perfilOperacionPermiso.IdOperacion;
                    PerfilOperacionPermisoBuscado.Crear = perfilOperacionPermiso.Crear;
                    PerfilOperacionPermisoBuscado.Editar = perfilOperacionPermiso.Editar;
                    PerfilOperacionPermisoBuscado.Eliminar = perfilOperacionPermiso.Eliminar;
                    PerfilOperacionPermisoBuscado.Ver = perfilOperacionPermiso.Ver;

                    var respNewPerfilOperacionPermiso = PerfilOperacionPermisoData.UpdatePerfilOperacionPermiso(PerfilOperacionPermisoBuscado,ip);

                    if (respNewPerfilOperacionPermiso > 0)
                    {
                        respAltaPerfilOperacionPermiso.Id = PerfilOperacionPermisoBuscado.Id;
                        respAltaPerfilOperacionPermiso.Codigo = "200";
                        respAltaPerfilOperacionPermiso.Mensaje = "OK";
                        return respAltaPerfilOperacionPermiso;
                    }
                    else
                    {
                        respAltaPerfilOperacionPermiso.Id = PerfilOperacionPermisoBuscado.Id;
                        respAltaPerfilOperacionPermiso.Codigo = "400";
                        respAltaPerfilOperacionPermiso.Mensaje = "Record not found";
                        return respAltaPerfilOperacionPermiso;
                    }
                }
                catch (Exception ex)
                {
                    respAltaPerfilOperacionPermiso.Id = PerfilOperacionPermisoBuscado.Id;
                    respAltaPerfilOperacionPermiso.Codigo = "400";
                    respAltaPerfilOperacionPermiso.Mensaje =ex.InnerException.Message;
                    return respAltaPerfilOperacionPermiso;
                }
            }            
        }

        public int AddPerfilOperacionPermisoList(List<RequestPerfilOperacionPermisoItem> reqPerfilOperacionPermisoList, String ip)
        {

            RequestPerfilOperacionPermiso perfilOperacionPermiso;

            try
            {
                for (int i = 0; i < reqPerfilOperacionPermisoList.Count; i++)
                {
                    perfilOperacionPermiso = new RequestPerfilOperacionPermiso();
                    perfilOperacionPermiso.IdPerfil = reqPerfilOperacionPermisoList[i].IdPerfil;
                    perfilOperacionPermiso.IdOperacion = reqPerfilOperacionPermisoList[i].IdOpercion;
                    perfilOperacionPermiso.Crear = reqPerfilOperacionPermisoList[i].Crear;
                    perfilOperacionPermiso.Editar = reqPerfilOperacionPermisoList[i].Editar;
                    perfilOperacionPermiso.Eliminar = reqPerfilOperacionPermisoList[i].Eliminar;
                    perfilOperacionPermiso.Ver = reqPerfilOperacionPermisoList[i].Ver;
                    AddPerfilOperacionPermiso(perfilOperacionPermiso,ip);
                }

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
           
        }

        public PerfilOperacionPermiso FindPerfilOperacionPermiso(long idPerfilOperacionPermiso)
        {
            PerfilOperacionPermiso respAltaPerfilOperacionPermiso = PerfilOperacionPermisoData.FindPerfilOperacionPermiso(idPerfilOperacionPermiso);
            if (respAltaPerfilOperacionPermiso == null)
            {
                respAltaPerfilOperacionPermiso = new PerfilOperacionPermiso();
                respAltaPerfilOperacionPermiso.Id = -1;
            }
            return respAltaPerfilOperacionPermiso;
        }

        public List<ResponsePerfilOperacionPermisoJoined> FindPerfilOperacionPermisoJoined(long idPerfil){

            List<ResponsePerfilOperacionPermisoJoined> respAltaPerfilOperacionPermiso = PerfilOperacionPermisoData.FindPerfilOperacionPermisoJoined(idPerfil);
            return respAltaPerfilOperacionPermiso;
        }
         public List<PerfilOperacionPermiso> FindAllPerfilOperacionPermiso(){
            List<PerfilOperacionPermiso> resPerfilOperacionPermisoRet = PerfilOperacionPermisoData.FindAllPerfilOperacionPermiso();
            return resPerfilOperacionPermisoRet;
        }
    }
}
