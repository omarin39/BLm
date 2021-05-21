using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessLineaProduccion
    {       
        public DataLineaProduccion LineaProduccionData = new();
        public ResponseGral AddLineaProduccion(RequestLineaProduccion LineaProduccion, String ip)
        {
            ResponseGral respAltaLineaProduccion = new();
            try
            {
                if (LineaProduccionData.FindNombreLProduccion(LineaProduccion) == false)
                {
                    LineaProduccion logNewRegistro = new();
                    logNewRegistro.IdNave = LineaProduccion.IdNave;
                    logNewRegistro.NombreLinea = LineaProduccion.NombreLinea;
                    logNewRegistro.DescripcionLinea = LineaProduccion.DescripcionLinea;
                    logNewRegistro.Activo = LineaProduccion.Activo;
                    long respNewUSR = LineaProduccionData.AddLineaProduccion(logNewRegistro, ip);
                    if (respNewUSR > 0)
                    {
                        respAltaLineaProduccion.Id = respNewUSR;
                        respAltaLineaProduccion.Codigo = "200";
                        respAltaLineaProduccion.Mensaje = "OK";
                        return respAltaLineaProduccion;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    respAltaLineaProduccion.Id = -1;
                    respAltaLineaProduccion.Codigo = "-1";
                    respAltaLineaProduccion.Mensaje = "Nombre Duplicado";
                    return respAltaLineaProduccion;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateLineaProduccion( RequestLineaProduccion LineaProduccion, String ip)
        {
            ResponseGral respAltaLineaProduccion = new();

   
            var LineaProduccionBuscado = FindLineaProduccion(LineaProduccion.Id);

            if (LineaProduccionBuscado == null)
            {
                return respAltaLineaProduccion;
            }
            else if (LineaProduccionBuscado.Id == -1)
            {
                respAltaLineaProduccion.Id = LineaProduccion.Id;
                respAltaLineaProduccion.Codigo = "400";
                respAltaLineaProduccion.Mensaje = "Not found";
                return respAltaLineaProduccion;
            }
            else
            {
                try
                {
                    if (LineaProduccionData.FindNombreLProduccion(LineaProduccion) == false)
                    {
                        LineaProduccionBuscado.Id = LineaProduccion.Id;
                        LineaProduccionBuscado.IdNave = LineaProduccion.IdNave;
                        LineaProduccionBuscado.NombreLinea = LineaProduccion.NombreLinea;
                        LineaProduccionBuscado.DescripcionLinea = LineaProduccion.DescripcionLinea;
                        LineaProduccionBuscado.Activo = LineaProduccion.Activo;
                        var respNewLineaProduccion = LineaProduccionData.UpdateLineaProduccion(LineaProduccionBuscado, ip);
                        if (respNewLineaProduccion > 0)
                        {
                            respAltaLineaProduccion.Id = LineaProduccionBuscado.Id;
                            respAltaLineaProduccion.Codigo = "200";
                            respAltaLineaProduccion.Mensaje = "OK";
                            return respAltaLineaProduccion;
                        }
                        else
                        {
                            respAltaLineaProduccion.Id = LineaProduccionBuscado.Id;
                            respAltaLineaProduccion.Codigo = "400";
                            respAltaLineaProduccion.Mensaje = "Record not found";
                            return respAltaLineaProduccion;
                        }
                    }
                    else
                    {
                        respAltaLineaProduccion.Id = -1;
                        respAltaLineaProduccion.Codigo = "-1";
                        respAltaLineaProduccion.Mensaje = "Nombre Duplicado";
                        return respAltaLineaProduccion;

                    }
                }
                catch (Exception ex)
                {
                    respAltaLineaProduccion.Id = LineaProduccionBuscado.Id;
                    respAltaLineaProduccion.Codigo = "400";
                    respAltaLineaProduccion.Mensaje = ex.InnerException.Message;
                    return respAltaLineaProduccion;
                }
            }
        }
        public LineaProduccion FindLineaProduccion(long IdLineaProduccionExt){
            LineaProduccion respAltaLineaProduccion = LineaProduccionData.FindLineaProduccion(IdLineaProduccionExt);
            if (respAltaLineaProduccion == null)
            {
                respAltaLineaProduccion = new LineaProduccion();
                respAltaLineaProduccion.Id = -1;
            }
            return respAltaLineaProduccion;
        }

        public List<LineaProduccion> FindLineaProduccionNave(long IdNave)
        {
            List<LineaProduccion> respAltaLineaProduccion = LineaProduccionData.FindLineaProduccionNave(IdNave);
            return respAltaLineaProduccion;
        }



        public List<LineaProduccion> FindAllLineaProduccion()
        {
            List<LineaProduccion> resLineaProduccionRet = LineaProduccionData.FindAllLineaProduccions();
            return resLineaProduccionRet;
        }


    }
}
