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
    public class ProcessPerfil
    {       
        public DataPerfil perfilData = new();
        public ResponseGral AddPerfil(RequestPerfiles perfil, String ip)
        {
            ResponseGral respAltaPerfil = new();
            try
            {
                Perfile logNewRegistro = new();
                logNewRegistro.Perfil = perfil.Perfil;
                logNewRegistro.Activo = perfil.Activo;
                long respNewUSR = perfilData.AddPerfil(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPerfil.Id = respNewUSR;
                    respAltaPerfil.Codigo = "200";
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
            else
            {
                try
                {
                    perfilBuscado.Perfil = perfil.Perfil;
                    perfilBuscado.Activo = perfil.Activo;
                    var respNewPerfil = perfilData.UpdatePerfil(perfilBuscado,ip);
                    if (respNewPerfil > 0)
                    {
                        respAltaPerfil.Id = perfilBuscado.Id;
                        respAltaPerfil.Codigo = "200";
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
        }
        public Perfile FindPerfil(long idPerfil){
            Perfile respAltaPerfil = perfilData.FindPerfil(idPerfil);
            if (respAltaPerfil == null)
            {
                respAltaPerfil.Id = -1;
            }
            return respAltaPerfil;
        }
        public List<Perfile> FindAllPerfil()
        {
            List<Perfile> resPerfilRet = perfilData.FindAllPerfil();
            return resPerfilRet;
        }
    }
}
