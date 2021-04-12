using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessPerfilOperacionPermiso
    {       
        public DataPerfilOperacionPermiso PerfilOperacionPermisoData = new();
        public ResponseGral AddPerfilOperacionPermiso(RequestPerfilOperacionPermiso PerfilOperacionPermiso)
        {
            ResponseGral respAltaPerfilOperacionPermiso = new();
            try
            {
                PerfilOperacionPermiso logNewRegistro = new();
                logNewRegistro.IdPerfil = PerfilOperacionPermiso.IdPerfil;
                logNewRegistro.IdOperacion = PerfilOperacionPermiso.IdOpercion;
                logNewRegistro.Crear = PerfilOperacionPermiso.Crear;
                logNewRegistro.Editar = PerfilOperacionPermiso.Editar;
                logNewRegistro.Eliminar = PerfilOperacionPermiso.Eliminar;
                logNewRegistro.Ver = PerfilOperacionPermiso.Ver;
                long respNewUSR = PerfilOperacionPermisoData.AddPerfilOperacionPermiso(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaPerfilOperacionPermiso.Id = respNewUSR;
                    respAltaPerfilOperacionPermiso.Codigo = "200";
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
        public ResponseGral UpdatePerfilOperacionPermiso(RequestPerfilOperacionPermiso PerfilOperacionPermiso)
        {
            ResponseGral respAltaPerfilOperacionPermiso = new();
            var PerfilOperacionPermisoBuscado = FindPerfilOperacionPermiso(PerfilOperacionPermiso.Id);
            if (PerfilOperacionPermisoBuscado == null)
            {
                return respAltaPerfilOperacionPermiso;
            }
            else
            {
                try
                {
                    PerfilOperacionPermisoBuscado.IdPerfil = PerfilOperacionPermiso.IdPerfil;
                    PerfilOperacionPermisoBuscado.IdOperacion = PerfilOperacionPermiso.IdOpercion;
                    PerfilOperacionPermisoBuscado.Crear = PerfilOperacionPermiso.Crear;
                    PerfilOperacionPermisoBuscado.Editar = PerfilOperacionPermiso.Editar;
                    PerfilOperacionPermisoBuscado.Eliminar = PerfilOperacionPermiso.Eliminar;
                    PerfilOperacionPermisoBuscado.Ver = PerfilOperacionPermiso.Ver;
                    var respNewPerfilOperacionPermiso = PerfilOperacionPermisoData.UpdatePerfilOperacionPermiso(PerfilOperacionPermisoBuscado);
                    if (respNewPerfilOperacionPermiso > 0)
                    {
                        respAltaPerfilOperacionPermiso.Id = PerfilOperacionPermisoBuscado.Id;
                        respAltaPerfilOperacionPermiso.Codigo = "200";
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
        }
        public PerfilOperacionPermiso FindPerfilOperacionPermiso(long idPerfilOperacionPermiso){
            PerfilOperacionPermiso respAltaPerfilOperacionPermiso = PerfilOperacionPermisoData.FindPerfilOperacionPermiso(idPerfilOperacionPermiso);
            if (respAltaPerfilOperacionPermiso == null)
            {
                respAltaPerfilOperacionPermiso.Id = -1;
            }
            return respAltaPerfilOperacionPermiso;
        }
         public List<PerfilOperacionPermiso> FindAllPerfilOperacionPermiso(){
            List<PerfilOperacionPermiso> resPerfilOperacionPermisoRet = PerfilOperacionPermisoData.FindAllPerfilOperacionPermiso();
            return resPerfilOperacionPermisoRet;
        }
    }
}
