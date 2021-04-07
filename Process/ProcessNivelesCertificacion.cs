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
    public class ProcessNivelesCertificacion
    {
        private ResponseNivelesCertificacion ResponseWS = new();
       
        public DataNivelesCertificacion NivelesCertificacionData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseNivelesCertificacion AddNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion)
        {
            ResponseNivelesCertificacion respAltaNivelesCertificacion = new();
            try
            {


                NivelesCertificacion logNewRegistro = new();
                logNewRegistro.DescNivelCertificacion = NivelesCertificacion.desc_nivel_certificacion;
            


                long respNewUSR = NivelesCertificacionData.AddNivelesCertificacion(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaNivelesCertificacion.Id = respNewUSR.ToString();
                    respAltaNivelesCertificacion.Codigo = "200";
                    
                    return respAltaNivelesCertificacion;

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

        public ResponseNivelesCertificacion UpdateNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion)
        {
            ResponseNivelesCertificacion respAltaNivelesCertificacion = new();
            NivelesCertificacion updAltaNivelesCertificacion = new();

            var nivelesCertificacionBuscado = FindNivelesCertificacion(NivelesCertificacion.Id);
            if(nivelesCertificacionBuscado==null){
                 return respAltaNivelesCertificacion;
            }else{
                try
                    {


                    nivelesCertificacionBuscado.DescNivelCertificacion = NivelesCertificacion.desc_nivel_certificacion;
                    


                    var respNewNivelesCertificacion = NivelesCertificacionData.UpdateNivelesCertificacion(nivelesCertificacionBuscado);
                        if (respNewNivelesCertificacion > 0)
                        {
                        respAltaNivelesCertificacion.Id = nivelesCertificacionBuscado.IdNivelCertificacion.ToString();
                            respAltaNivelesCertificacion.Codigo = "200";
                        
                            return respAltaNivelesCertificacion;

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

        public NivelesCertificacion FindNivelesCertificacion(long idNivelesCertificacion){

            NivelesCertificacion respAltaNivelesCertificacion = new();

            respAltaNivelesCertificacion = NivelesCertificacionData.FindNivelesCertificacion(idNivelesCertificacion);
            if(respAltaNivelesCertificacion==null){
                respAltaNivelesCertificacion.IdNivelCertificacion = -1;
            }
          
              return respAltaNivelesCertificacion;
        }

         public List<NivelesCertificacion> FindAllNivelesCertificacion(){
            List<NivelesCertificacion> resNivelesCertificacionRet = new List<NivelesCertificacion>();
            resNivelesCertificacionRet =  NivelesCertificacionData.FindAllNivelesCertificacion();
           
            return resNivelesCertificacionRet;
        }

       


    }
}
