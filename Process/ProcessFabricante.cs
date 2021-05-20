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
    public class ProcessFabricante
    {       
        public DataFabricante FabricanteData = new();
        public ResponseGral AddFabricante(RequestFabricante Fabricante, String ip)
        {
            ResponseGral respAltaFabricante = new();
            try
            {
                if (FabricanteData.ValidaClaveExistente2(Fabricante.Email) == false)
                {
                    if (FabricanteData.ValidaClaveExistente(Fabricante.Telefono) == false)
                    {
                        Fabricante logNewRegistro = new();
                        logNewRegistro.Nombre = Fabricante.Nombre;
                        logNewRegistro.Contacto = Fabricante.Contacto;
                        logNewRegistro.Email = Fabricante.Email;
                        logNewRegistro.Telefono = Fabricante.Telefono;
                        logNewRegistro.Activo = Fabricante.Activo;
                        long respNewUSR = FabricanteData.AddFabricante(logNewRegistro, ip);
                        if (respNewUSR > 0)
                        {
                            respAltaFabricante.Id = respNewUSR;
                            respAltaFabricante.Codigo = "200";
                            respAltaFabricante.Mensaje = "OK";
                            return respAltaFabricante;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        respAltaFabricante.Id = -1;
                        respAltaFabricante.Codigo = "-1";
                        respAltaFabricante.Mensaje = "Telefono Duplicado";
                        return respAltaFabricante;

                    }
                }
                else
                {
                    respAltaFabricante.Id = -1;
                    respAltaFabricante.Codigo = "-1";
                    respAltaFabricante.Mensaje = "Email Duplicado";
                    return respAltaFabricante;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResponseGral UpdateFabricante(RequestFabricante Fabricante, String ip)
        {
            ResponseGral respAltaFabricante = new();
            var FabricanteBuscado = FindFabricante(Fabricante.IdFabricante);
            if(FabricanteBuscado==null){
                 return respAltaFabricante;
            }
            else if (FabricanteBuscado.IdFabricante == -1)
            {
                respAltaFabricante.Id = Fabricante.IdFabricante;
                respAltaFabricante.Codigo = "400";
                respAltaFabricante.Mensaje = "Not found";
                return respAltaFabricante;
            }
            else
            {
                try
                {
                    FabricanteBuscado.Nombre = Fabricante.Nombre;
                    FabricanteBuscado.Contacto = Fabricante.Contacto;
                    FabricanteBuscado.Email = Fabricante.Email;
                    FabricanteBuscado.Telefono = Fabricante.Telefono;
                    FabricanteBuscado.Activo = Fabricante.Activo;
                    var respNewFabricante = FabricanteData.UpdateFabricante(FabricanteBuscado,ip);
                    if (respNewFabricante > 0)
                    {
                        respAltaFabricante.Id = FabricanteBuscado.IdFabricante;
                        respAltaFabricante.Codigo = "200";
                        respAltaFabricante.Mensaje = "OK";
                        return respAltaFabricante;
                    }
                    else
                    {
                        respAltaFabricante.Id = FabricanteBuscado.IdFabricante;
                        respAltaFabricante.Codigo = "400";
                        respAltaFabricante.Mensaje = "Record not found";
                        return respAltaFabricante;
                    }
                }
                catch (Exception ex)
                {
                    respAltaFabricante.Id = FabricanteBuscado.IdFabricante;
                    respAltaFabricante.Codigo = "400";
                    respAltaFabricante.Mensaje = ex.InnerException.Message;
                    return respAltaFabricante;
                }
            }
        }
        public Fabricante FindFabricante(long idFabricante)
        {
            Fabricante respAltaFabricante = FabricanteData.FindFabricante(idFabricante);
            if (respAltaFabricante == null)
            {
                respAltaFabricante = new Fabricante();
                respAltaFabricante.IdFabricante = -1;
            }
            return respAltaFabricante;
        }
        public List<Fabricante> FindAllFabricante(){
            List<Fabricante> resFabricanteRet = FabricanteData.FindAllFabricante();  
            return resFabricanteRet;
        }
    }
}
