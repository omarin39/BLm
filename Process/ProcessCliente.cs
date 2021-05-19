using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;

namespace APIRestV2.Controllers.Process
{
    public class ProcessCliente
    {
        public DataCliente ClienteData = new();
        public ResponseGral AddCliente(RequestCliente Cliente, String ip)
        {
            ResponseGral respAltaCliente = new();
            try
            {
                if (ClienteData.FindClienteEmailTelefono(1, Cliente)==null)
                {
                    if (ClienteData.FindClienteEmailTelefono(2, Cliente) == null)
                    {
                        Cliente logNewRegistro = new();
                        logNewRegistro.Nombre = Cliente.Nombre;
                        logNewRegistro.Contacto = Cliente.Contacto;
                        logNewRegistro.Email = Cliente.Email;
                        logNewRegistro.Telefono = Cliente.Telefono;
                        logNewRegistro.Activo = Cliente.Activo;
                        long respNewUSR = ClienteData.AddCliente(logNewRegistro, ip);
                        if (respNewUSR > 0)
                        {
                            respAltaCliente.Id = respNewUSR;
                            respAltaCliente.Codigo = "200";
                            respAltaCliente.Mensaje = "OK";
                            return respAltaCliente;
                        }
                        else
                        {
                            return null;
                        }

                    }
                    else
                    {
                        respAltaCliente.Id = -2;
                        respAltaCliente.Codigo = "-2";
                        respAltaCliente.Mensaje = "Teléfono Duplicado";
                        return respAltaCliente;
                    }
                    
                }
                else
                {
                    respAltaCliente.Id = -1;
                    respAltaCliente.Codigo = "-1";
                    respAltaCliente.Mensaje = "Correo Duplicado";
                    return respAltaCliente;

                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResponseGral UpdateCliente(RequestCliente Cliente, String ip)
        {
            ResponseGral respAltaCliente = new();
            var clienteBuscado = FindCliente(Cliente.IdCliente);
            if (clienteBuscado == null)
            {
                return respAltaCliente;
            }
            else if (clienteBuscado.IdCliente == -1)
            {
                respAltaCliente.Id = Cliente.IdCliente;
                respAltaCliente.Codigo = "400";
                respAltaCliente.Mensaje = "Not found";
                return respAltaCliente;
            }
            else
            {
                try
                {
                    if (ClienteData.FindClienteEmailTelefono(1, Cliente) == null)
                    {
                        if (ClienteData.FindClienteEmailTelefono(2, Cliente) == null)
                        {
                            clienteBuscado.Nombre = Cliente.Nombre;
                            clienteBuscado.Contacto = Cliente.Contacto;
                            clienteBuscado.Email = Cliente.Email;
                            clienteBuscado.Telefono = Cliente.Telefono;
                            clienteBuscado.Activo = Cliente.Activo;
                            var respNewCliente = ClienteData.UpdateCliente(clienteBuscado, ip);
                            if (respNewCliente > 0)
                            {
                                respAltaCliente.Id = clienteBuscado.IdCliente;
                                respAltaCliente.Codigo = "200";
                                respAltaCliente.Mensaje = "OK";
                                return respAltaCliente;
                            }
                            else
                            {
                                respAltaCliente.Id = clienteBuscado.IdCliente;
                                respAltaCliente.Codigo = "400";
                                respAltaCliente.Mensaje = "Record not found";
                                return respAltaCliente;
                            }

                        }
                        else
                        {
                            respAltaCliente.Id = -2;
                            respAltaCliente.Codigo = "-2";
                            respAltaCliente.Mensaje = "Teléfono Duplicado";
                            return respAltaCliente;
                        }

                    }
                    else
                    {
                        respAltaCliente.Id = -1;
                        respAltaCliente.Codigo = "-1";
                        respAltaCliente.Mensaje = "Correo Duplicado";
                        return respAltaCliente;

                    }


                    
                }
                catch (Exception ex)
                {
                    respAltaCliente.Id = clienteBuscado.IdCliente;
                    respAltaCliente.Codigo = "400";
                    respAltaCliente.Mensaje = ex.InnerException.Message;
                    return respAltaCliente;
                }
            }
        }
        public Cliente FindCliente(long idCliente)
        {
            Cliente respAltaCliente = ClienteData.FindCliente(idCliente);
            if (respAltaCliente == null)
            {
                respAltaCliente = new Cliente();
                respAltaCliente.IdCliente = -1;
            }
            return respAltaCliente;
        }
        public List<Cliente> FindAllCliente()
        {
            List<Cliente> resClienteRet = ClienteData.FindAllCliente();
            return resClienteRet;
        }
    }
}
