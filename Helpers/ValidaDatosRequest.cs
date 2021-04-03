using APIRest.Common;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace APIRest.Helpers
{

    public class ValidaDatosRequest 
    {
        public static IConfiguration Configuration { get; set; }
        private ComplementosFailResponse failWS = new();
        public static UsrKey paramUsrValida = new();
        private ResponseUsersValida ResponseValida = new();
        private RequestUsers USRVAlidados = new();
        private int cont = 0;

        public ValidaDatosRequest()
        {
        }


        public ResponseUsersValida ValidaRequestUSER(List<RequestUsers> ReqUser, List<ResourceValidacionesCampo> CamposValida, IConfiguration configuration)
        {
            IConfiguration Configuration = configuration;
            Configuration.GetSection("UsrValidEntry").Bind(paramUsrValida);
            ResponseValida.Bien = new();
            ResponseValida.Mal = new();

            foreach (var reqUSR in ReqUser)
            {
                Type te = reqUSR.GetType();
                PropertyInfo[] props = te.GetProperties();
                if (reqUSR.User.Trim() == paramUsrValida.UserName.Trim() && reqUSR.Pass.Trim() == paramUsrValida.Password.Trim())
                {
                    foreach (var prop in props)
                    {
                        if (prop.Name != "Operacion" && prop.Name != "User" && prop.Name != "Pass")
                        {

                            ResourceValidacionesCampo ValidaActual = new();
                            foreach (var item in CamposValida)
                            {
                                if (item.Nombre.ToUpper() == prop.Name.ToUpper())
                                {
                                    ValidaActual = item;
                                    break;
                                }
                            }
                            var ValorPropiedad = prop.GetValue(reqUSR);

                            switch (ValidaActual.Requerido)
                            {
                                case true:
                                    switch (ValidaActual.TipoDato)
                                    {
                                        case "int":
                                            if(ValidaRequerido(ValorPropiedad))
                                            {
                                                if(!ValidaTamaño(ValorPropiedad,ValidaActual)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            }
                                            else
                                            {
                                                CrearErrorRequerido(ValidaActual, reqUSR, prop);
                                            }
                                            break;
                                        case "string":
                                            if (ValidaRequerido(ValorPropiedad))
                                            {
                                                if(!ValidaTamaño(ValorPropiedad, ValidaActual)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            }
                                            else
                                            {
                                                CrearErrorRequerido(ValidaActual, reqUSR, prop);
                                                
                                            }
                                            break;
                                        case "date":
                                            if (ValidaRequerido(ValorPropiedad))
                                            {
                                                DateTime FechaValida;
                                                var formatoFecha = "yyyy/mm/dd";
                                                if(!DateTime.TryParseExact(ValorPropiedad.ToString(), formatoFecha, null, System.Globalization.DateTimeStyles.None, out FechaValida)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            }
                                            else
                                            {
                                                CrearErrorRequerido(ValidaActual, reqUSR, prop);
                                                
                                            }
                                            break;
                                        case "email":
                                            if (ValidaRequerido(ValorPropiedad))
                                            {
                                                if(!Validaemail(ValorPropiedad.ToString())) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            }
                                            else
                                            {
                                                CrearErrorRequerido(ValidaActual, reqUSR, prop);
                                                
                                            }
                                            
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                    break;
                                default:
                                    switch (ValidaActual.TipoDato)
                                    {
                                        case "int":
                                            if(!ValidaTamaño(ValorPropiedad, ValidaActual)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            break;
                                        case "string":
                                            if(!ValidaTamaño(ValorPropiedad, ValidaActual)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            break;
                                        case "date":
                                            DateTime FechaValida;
                                            var formatoFecha = "yyyy/mm/dd";
                                            if (!DateTime.TryParseExact(ValorPropiedad.ToString(), formatoFecha, null, System.Globalization.DateTimeStyles.None, out FechaValida)) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            break;
                                        case "email":
                                            if (!Validaemail(ValorPropiedad.ToString())) CrearErrorFormato(ValidaActual, reqUSR, prop);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }


                        }

                    }
                    //var res=CamposValida.Contains();

                    if (cont == 0) {
                        ResponseValida.Bien.Add(reqUSR);
                    }
                }
                else
                {
                    failWS = new();
                    failWS.Codigo = "433";
                    failWS.Mensaje = "credenciales incorrectas";
                    failWS.Operacion = reqUSR.Operacion;
                    failWS.NoNomina = reqUSR.NoNomina.ToString();
                    ResponseValida.Mal.Add(failWS);
                }
            }
            return ResponseValida;
        }

        public bool ValidaRequerido(object ValorPropiedad)
        {
            return ValorPropiedad.ToString().Length > 0;
        }

        public bool ValidaTamaño(object ValorPropiedad, ResourceValidacionesCampo ValidaActual)
        {
            return ValorPropiedad.ToString().Length <= Int32.Parse(ValidaActual.TamañoCampo.ToString());
        }
        public void CrearErrorRequerido(ResourceValidacionesCampo ValidaActual, RequestUsers reqUSR, PropertyInfo prop)
        {
            ComplementosFailResponse failWSERR = new();            
            failWSERR.Codigo = ValidaActual.CodigoErrorRequerido.ToString();
            failWSERR.Mensaje = prop.Name.ToString() + " " + ValidaActual.MensajeErrorRequerido;
            failWSERR.Operacion = reqUSR.Operacion;
            failWSERR.NoNomina = reqUSR.NoNomina.ToString();
            ResponseValida.Mal.Add(failWSERR);
            cont++;

        }
        public void CrearErrorFormato(ResourceValidacionesCampo ValidaActual, RequestUsers reqUSR, PropertyInfo prop)
        {
            ComplementosFailResponse failWSERR = new();
            failWSERR.Codigo = ValidaActual.CodigoErrorFormato.ToString();
            failWSERR.Mensaje = prop.Name.ToString() + " " + ValidaActual.MensajeErrorFormato;
            failWSERR.Operacion = reqUSR.Operacion;
            failWSERR.NoNomina = reqUSR.NoNomina.ToString();
            ResponseValida.Mal.Add(failWSERR);
            cont++;

        }

        private Boolean Validaemail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }

}
