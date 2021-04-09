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
                logNewRegistro.Nombre = Cliente.Nombre;
                logNewRegistro.Contacto = Cliente.Contacto;
                logNewRegistro.Email = Cliente.Email;
                logNewRegistro.Telefono = Cliente.Telefono;
                logNewRegistro.Activo = Cliente.Activo;


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

            var clienteBuscado = FindCliente(Cliente.IdCliente);
            if(clienteBuscado==null){
                 return respAltaCliente;
            }else{
                try
                    {

                    
                   

                    clienteBuscado.Nombre = Cliente.Nombre;
                    clienteBuscado.Contacto = Cliente.Contacto;
                    clienteBuscado.Email = Cliente.Email;
                    clienteBuscado.Telefono = Cliente.Telefono;
                    clienteBuscado.Activo = Cliente.Activo;



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
