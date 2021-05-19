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
    public class ProcessPerfil
    {       
        public DataPerfil perfilData = new();
        public ResponseGral AddPerfil(RequestPerfiles perfil, String ip)
        {
            ResponseGral respAltaPerfil = new();
            try
            {
                Perfil logNewRegistro = new();
                logNewRegistro.Perfil1 = perfil.Perfil1;
                logNewRegistro.Activo = perfil.Activo;
                long respNewUSR = perfilData.AddPerfil(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPerfil.Id = respNewUSR;
                    respAltaPerfil.Codigo = "200";
                    respAltaPerfil.Mensaje = "OK";
                    return respAltaPerfil;
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

        public ResponseGral UpdatePerfil( RequestPerfiles perfil, String ip)
        {
            ResponseGral respAltaPerfil = new();

            if (perfil.Id == 1 && perfil.Activo==false)
            {
                respAltaPerfil.Id = perfil.Id;
                respAltaPerfil.Codigo = "501";
                respAltaPerfil.Mensaje = "El perfil de Administrador no puede desactivarse";
                return respAltaPerfil;

            }
           else  if (perfil.Id == 2 && perfil.Activo == false)
            {
                respAltaPerfil.Id = perfil.Id;
                respAltaPerfil.Codigo = "502";
                respAltaPerfil.Mensaje = "El perfil de Usuario no puede desactivarse";
                return respAltaPerfil;

            }
            //Valida si un perfil dif a admin o usuer tiene usuarios asociados
            if (perfil.Id > 2 && perfil.Activo == false)
            {
                DataEmpleado empleadoData = new();
                List<Empleado> resEmpleadoRet = empleadoData.FindAllEmpleadosPorPerfil(perfil.Id);
                if (resEmpleadoRet.Count > 0)
                {
                    respAltaPerfil.Id = perfil.Id;
                    respAltaPerfil.Codigo = "503";
                    respAltaPerfil.Mensaje = "El perfil no puede desactivarse, por que tiene "+resEmpleadoRet.Count.ToString() +" empleados asociados.";
                    return respAltaPerfil;
                }
            }



            var perfilBuscado = FindPerfil(perfil.Id);
            if (perfilBuscado == null)
            {
                return respAltaPerfil;
            }
            else if (perfilBuscado.Id == -1)
            {
                respAltaPerfil.Id = perfil.Id;
                respAltaPerfil.Codigo = "400";
                respAltaPerfil.Mensaje = "Not found";
                return respAltaPerfil;
            }
            else
            {
                try
                {
                    perfilBuscado.Perfil1 = perfil.Perfil1;
                    perfilBuscado.Activo = perfil.Activo;
                    var respNewPerfil = perfilData.UpdatePerfil(perfilBuscado,ip);
                    if (respNewPerfil > 0)
                    {
                        respAltaPerfil.Id = perfilBuscado.Id;
                        respAltaPerfil.Codigo = "200";
                        respAltaPerfil.Mensaje = "OK";
                        return respAltaPerfil;
                    }
                    else
                    {
                        respAltaPerfil.Id = perfilBuscado.Id;
                        respAltaPerfil.Codigo = "400";
                        respAltaPerfil.Mensaje = "Record not found";
                        return respAltaPerfil;
                    }
                }
                catch (Exception ex)
                {
                    respAltaPerfil.Id = perfilBuscado.Id;
                    respAltaPerfil.Codigo = "400";
                    respAltaPerfil.Mensaje = ex.InnerException.Message;
                    return respAltaPerfil;
                }
            }
        }
        public Perfil FindPerfil(long idPerfil){
            Perfil respAltaPerfil = perfilData.FindPerfil(idPerfil);
            if (respAltaPerfil == null)
            {
                respAltaPerfil = new Perfil();
                respAltaPerfil.Id = -1;
            }
            return respAltaPerfil;
        }
        public List<Perfil> FindAllPerfil()
        {
            List<Perfil> resPerfilRet = perfilData.FindAllPerfil();
            return resPerfilRet;
        }
    }
}
