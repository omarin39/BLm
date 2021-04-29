using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessLineaProduccion
    {       
        public DataLineaProduccion LineaProduccionData = new();
        public ResponseGral AddLineaProduccion(RequestLineaProduccion LineaProduccion, String ip)
        {
            ResponseGral respAltaLineaProduccion = new();
            try
            {
                LineasProduccion logNewRegistro = new();
                logNewRegistro.IdNave = LineaProduccion.IdNave;
                logNewRegistro.NombreLinea = LineaProduccion.NombreLinea;
                logNewRegistro.DescripcionLinea = LineaProduccion.DescripcionLinea;
                logNewRegistro.Activo = LineaProduccion.Activo;
                long respNewUSR = LineaProduccionData.AddLineaProduccion(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaLineaProduccion.Id = respNewUSR;
                    respAltaLineaProduccion.Codigo = "200";
                    return respAltaLineaProduccion;
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

        public ResponseGral UpdateLineaProduccion( RequestLineaProduccion LineaProduccion, String ip)
        {
            ResponseGral respAltaLineaProduccion = new();

   
            var LineaProduccionBuscado = FindLineaProduccion(LineaProduccion.Id);


            if (LineaProduccion.Activo == false) { 
                if (LineaProduccionBuscado.IdNave  > 0)
            {
                respAltaLineaProduccion.Id = LineaProduccion.Id;
                respAltaLineaProduccion.Codigo = "503";
                respAltaLineaProduccion.Mensaje = "La LineaProduccion no puede desactivarse, por que tiene 1 nave asociadas.";
                return respAltaLineaProduccion;
            }
            }




            if (LineaProduccionBuscado == null)
            {
                return respAltaLineaProduccion;
            }
            else
            {
                try
                {
                    LineaProduccionBuscado.Id = LineaProduccion.Id;
                    LineaProduccionBuscado.IdNave = LineaProduccion.IdNave;
                    LineaProduccionBuscado.NombreLinea = LineaProduccion.NombreLinea;
                    LineaProduccionBuscado.DescripcionLinea = LineaProduccion.DescripcionLinea;
                    LineaProduccionBuscado.Activo = LineaProduccion.Activo;
                    var respNewLineaProduccion = LineaProduccionData.UpdateLineaProduccion(LineaProduccionBuscado,ip);
                    if (respNewLineaProduccion > 0)
                    {
                        respAltaLineaProduccion.Id = LineaProduccionBuscado.Id;
                        respAltaLineaProduccion.Codigo = "200";
                        return respAltaLineaProduccion;
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
        public LineasProduccion FindLineaProduccion(long IdLineaProduccionExt){
            LineasProduccion respAltaLineaProduccion = LineaProduccionData.FindLineaProduccion(IdLineaProduccionExt);
            if (respAltaLineaProduccion == null)
            {
                respAltaLineaProduccion.Id = -1;
            }
            return respAltaLineaProduccion;
        }

        public LineasProduccion FindLineaProduccionNave(long IdLineaProduccionExt)
        {
            LineasProduccion respAltaLineaProduccion = LineaProduccionData.FindLineaProduccionNave(IdLineaProduccionExt);
            if (respAltaLineaProduccion == null)
            {
                respAltaLineaProduccion.Id = -1;
            }
            return respAltaLineaProduccion;
        }



        public List<LineasProduccion> FindAllLineaProduccion()
        {
            List<LineasProduccion> resLineaProduccionRet = LineaProduccionData.FindAllLineaProduccions();
            return resLineaProduccionRet;
        }


    }
}
