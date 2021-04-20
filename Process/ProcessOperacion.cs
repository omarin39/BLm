﻿using APIRest.DataModels;
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
    public class ProcessOperacion
    {       
        public DataOperacion operacionData = new();
        public ResponseGral AddOperacion(RequestOperacion operacion)
        {
            ResponseGral respAltaOperacion = new();
            try
            {
                Operacione logNewRegistro = new();
                logNewRegistro.Operacion = operacion.Operacion;
                logNewRegistro.NombreMenu = operacion.Nombre_Menu;
                logNewRegistro.NombrePagina = operacion.Nombre_Pagina;
                logNewRegistro.IdMenu = operacion.Id_Menu;
                logNewRegistro.Activo = operacion.Activo;
                long respNewOperacion = operacionData.AddOperacion(logNewRegistro);
                if(respNewOperacion > 0)
                {

                    ProcessPerfil ProcPerfil = new();
                    ProcessPerfilOperacionPermiso procPerfilOperacionPermiso = new();

                    List<Perfile> lstPerfiles = ProcPerfil.FindAllPerfil();

                    foreach (var perfil in lstPerfiles)
                    {
                        var _permiso = new RequestPerfilOperacionPermiso();
                        _permiso.IdOperacion = respNewOperacion;
                        _permiso.IdPerfil = perfil.Id;
                        _permiso.Crear = false;
                        _permiso.Ver = false;
                        _permiso.Eliminar = false;
                        _permiso.Editar = false;
                        

                        var result = procPerfilOperacionPermiso.AddPerfilOperacionPermiso(_permiso);
                    }

                    respAltaOperacion.Id = respNewOperacion;
                    respAltaOperacion.Codigo = "200";
                    return respAltaOperacion;
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
        public ResponseGral UpdateOperacion(RequestOperacion operacion)
        {
            ResponseGral respAltaOperacion = new();
            var operacionBuscado = FindOperacion(operacion.Id);
            if (operacionBuscado == null)
            {
                return respAltaOperacion;
            }
            else
            {
                try
                {
                    operacionBuscado.Operacion = operacion.Operacion;
                    operacionBuscado.NombreMenu = operacion.Nombre_Menu;
                    operacionBuscado.NombrePagina = operacion.Nombre_Pagina;
                    operacionBuscado.Activo = operacion.Activo;
                    var respNewOperacion = operacionData.UpdateOperacion(operacionBuscado);
                    if (respNewOperacion > 0)
                    {
                        respAltaOperacion.Id = operacionBuscado.Id;
                        respAltaOperacion.Codigo = "200";
                        return respAltaOperacion;
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
        public Operacione FindOperacion(long idOperacion)
        {
            Operacione respAltaOperacion = operacionData.FindOperacion(idOperacion);
            if (respAltaOperacion == null)
            {
                respAltaOperacion.Id = -1;
            }
            return respAltaOperacion;
        }
        public List<Operacione> FindAllOperacion()
        {
            List<Operacione> resOperacionRet = operacionData.FindAllOperacion();
            return resOperacionRet;
        }
    }
}
