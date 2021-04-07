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
    public class ProcessOperacion
    {
        private ResponseOperacion ResponseWS = new();
       
        public DataOperacion operacionData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseOperacion AddOperacion(RequestOperacion operacion)
        {
            ResponseOperacion respAltaOperacion = new();
            try
            {


                Operacione logNewRegistro = new();
                logNewRegistro.Operacion = operacion.Operacion;
                logNewRegistro.NombreMenu = operacion.Nombre_Menu;
                logNewRegistro.NombrePagina = operacion.Nombre_Pagina;
                logNewRegistro.Estatus = operacion.Estatus;


                long respNewUSR = operacionData.AddOperacion(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaOperacion.Id = respNewUSR.ToString();
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

        public ResponseOperacion UpdateOperacion(RequestOperacion operacion)
        {
            ResponseOperacion respAltaOperacion = new();
            Operacione updAltaOperacion = new();

            var operacionBuscado = FindOperacion(operacion.Id);
            if(operacionBuscado==null){
                 return respAltaOperacion;
            }else{
                try
                    {

                    
                    operacionBuscado.Operacion = operacion.Operacion;
                    operacionBuscado.NombreMenu = operacion.Nombre_Menu;
                    operacionBuscado.NombrePagina = operacion.Nombre_Pagina;
                    operacionBuscado.Estatus = operacion.Estatus;



                    var respNewOperacion = operacionData.UpdateOperacion(operacionBuscado);
                        if (respNewOperacion > 0)
                        {
                        respAltaOperacion.Id = operacionBuscado.Id.ToString();
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

        public Operacione FindOperacion(long idOperacion){

            Operacione respAltaOperacion = new();

            respAltaOperacion = operacionData.FindOperacion(idOperacion);
            if(respAltaOperacion==null){
                respAltaOperacion.Id = -1;
            }
          
              return respAltaOperacion;
        }

         public List<Operacione> FindAllOperacion(){
            List<Operacione> resOperacionRet = new List<Operacione>();
            resOperacionRet =  operacionData.FindAllOperacion();
           
            return resOperacionRet;
        }

       


    }
}
