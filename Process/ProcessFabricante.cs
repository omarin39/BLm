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
    public class ProcessFabricante
    {       
        public DataFabricante FabricanteData = new();
        public ResponseGral AddFabricante(RequestFabricante Fabricante, String ip)
        {
            ResponseGral respAltaFabricante = new();
            try
            {
                Fabricante logNewRegistro = new();
                logNewRegistro.Nombre = Fabricante.Nombre;
                logNewRegistro.Contacto = Fabricante.Contacto;
                logNewRegistro.Email = Fabricante.Email;
                logNewRegistro.Telefono = Fabricante.Telefono;
                logNewRegistro.Activo = Fabricante.Activo;
                long respNewUSR = FabricanteData.AddFabricante(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaFabricante.Id = respNewUSR;
                    respAltaFabricante.Codigo = "200";
                    return respAltaFabricante;
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
        public ResponseGral UpdateFabricante(RequestFabricante Fabricante, String ip)
        {
            ResponseGral respAltaFabricante = new();
            var FabricanteBuscado = FindFabricante(Fabricante.IdFabricante);
            if(FabricanteBuscado==null){
                 return respAltaFabricante;
            }else{
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
                        return respAltaFabricante;
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
        public Fabricante FindFabricante(long idFabricante)
        {
            Fabricante respAltaFabricante = FabricanteData.FindFabricante(idFabricante);
            if (respAltaFabricante == null)
            {
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
