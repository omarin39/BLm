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
    public class ProcessCliente
    {
        private ResponseCliente ResponseWS = new();
       
        public DataCliente ClienteData = new();
       
// public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseCliente AddCliente(RequestCliente Cliente)
        {
            ResponseCliente respAltaCliente = new();
            try
            {


                Cliente logNewRegistro = new();
                logNewRegistro.Nombre = Cliente.nombre;
                logNewRegistro.Contacto = Cliente.contacto;
                logNewRegistro.Email = Cliente.email;
                logNewRegistro.Telefono = Cliente.telefono;


                long respNewUSR = ClienteData.AddCliente(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaCliente.Id = respNewUSR.ToString();
                    respAltaCliente.Codigo = "200";
                    
                    return respAltaCliente;

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

        public ResponseCliente UpdateCliente(RequestCliente Cliente)
        {
            ResponseCliente respAltaCliente = new();
            Cliente updAltaCliente = new();

            var clienteBuscado = FindCliente(Cliente.Id);
            if(clienteBuscado==null){
                 return respAltaCliente;
            }else{
                try
                    {

                    
                   

                    clienteBuscado.Nombre = Cliente.nombre;
                    clienteBuscado.Contacto = Cliente.contacto;
                    clienteBuscado.Email = Cliente.email;
                    clienteBuscado.Telefono = Cliente.telefono;



                    var respNewCliente = ClienteData.UpdateCliente(clienteBuscado);
                        if (respNewCliente > 0)
                        {
                        respAltaCliente.Id = clienteBuscado.IdCliente.ToString();
                            respAltaCliente.Codigo = "200";
                        
                            return respAltaCliente;

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

        public Cliente FindCliente(long idCliente){

            Cliente respAltaCliente = new();

            respAltaCliente = ClienteData.FindCliente(idCliente);
            if(respAltaCliente==null){
                respAltaCliente.IdCliente = -1;
            }
          
              return respAltaCliente;
        }

         public List<Cliente> FindAllCliente(){
            List<Cliente> resClienteRet = new List<Cliente>();
            resClienteRet =  ClienteData.FindAllCliente();
           
            return resClienteRet;
        }

       


    }
}
