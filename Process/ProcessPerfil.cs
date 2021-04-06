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
        private ResponsePerfiles ResponseWS = new();
       
        public DataPerfil perfilData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponsePerfiles AddPerfil(RequestPerfiles perfil)
        {
            ResponsePerfiles respAltaPerfil = new();
            try
            {
                

                Perfile logNewRegistro = new();
                logNewRegistro.Perfil = perfil.Perfil;
                logNewRegistro.Activo = perfil.Activo;
                

                long respNewUSR = perfilData.AddPerfil(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaPerfil.Id = respNewUSR.ToString();
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

        public ResponsePerfiles UpdatePerfil( RequestPerfiles perfil)
        {
            ResponsePerfiles respAltaPerfil = new();
            Perfile updAltaPerfil = new();

            var perfilBuscado = FindPerfil(perfil.Id);
            if(perfilBuscado==null){
                 return respAltaPerfil;
            }else{
                try
                    {

                        perfilBuscado.Perfil=perfil.Perfil;
                        perfilBuscado.Activo=perfil.Activo;
                      


                        var respNewPerfil = perfilData.UpdatePerfil(perfilBuscado);
                        if (respNewPerfil > 0)
                        {
                            respAltaPerfil.Id = perfilBuscado.Id.ToString();
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

            Perfile respAltaPerfil = new();

            respAltaPerfil = perfilData.FindPerfil(idPerfil);
            if(respAltaPerfil==null){
                respAltaPerfil.Id = -1;
            }
          
              return respAltaPerfil;
        }

         public List<Perfile> FindAllPerfil(){
            List<Perfile> resPerfilRet = new List<Perfile>();
            resPerfilRet =  perfilData.FindAllPerfil();
           
            return resPerfilRet;
        }

       


    }
}
