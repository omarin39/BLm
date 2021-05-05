using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Process
{
    public class ProcessIdioma
    {
        public DataIdioma IdiomaData = new();
        public ResponseGral AddIdioma(RequestIdiomas _idioma, String ip)
        {
            ResponseGral respAltaIdioma = new();
            try
            {
                Idioma logNewRegistro = new();
                logNewRegistro.CodigoIdioma = _idioma.CodigoIdioma;
                logNewRegistro.Idioma1 = _idioma.Idioma1;
                logNewRegistro.Activo = _idioma.Activo;
                long respNewIdioma = IdiomaData.AddIdioma(logNewRegistro,ip);
                if (respNewIdioma > 0)
                {
                    respAltaIdioma.Id = respNewIdioma;
                    respAltaIdioma.Codigo = "200";
                    respAltaIdioma.Mensaje = "OK";
                    return respAltaIdioma;
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
        public ResponseGral UpdateIdioma(RequestIdiomas _idioma, String ip)
        {
            ResponseGral respAltaIdioma = new();
            var IdiomaBuscado = FindIdioma(_idioma.IdIdioma);
            if (IdiomaBuscado == null)
            {
                return respAltaIdioma;
            }
            else if (IdiomaBuscado.IdIdioma == -1)
            {
                respAltaIdioma.Id = _idioma.IdIdioma;
                respAltaIdioma.Codigo = "400";
                respAltaIdioma.Mensaje = "Not found";
                return respAltaIdioma;
            }
            else
            {
                try
                {
                    IdiomaBuscado.Idioma1 = _idioma.Idioma1;
                    IdiomaBuscado.CodigoIdioma = _idioma.CodigoIdioma;
                    IdiomaBuscado.Activo = _idioma.Activo;
                    var respNewIdioma = IdiomaData.UpdateIdioma(IdiomaBuscado,ip);
                    if (respNewIdioma > 0)
                    {
                        respAltaIdioma.Id = IdiomaBuscado.IdIdioma;
                        respAltaIdioma.Codigo = "200";
                        respAltaIdioma.Mensaje = "OK";
                        return respAltaIdioma;
                    }
                    else
                    {
                        respAltaIdioma.Id = IdiomaBuscado.IdIdioma;
                        respAltaIdioma.Codigo = "400";
                        respAltaIdioma.Mensaje = "Record not found";
                        return respAltaIdioma;
                    }
                }
                catch (Exception ex)
                {

                    respAltaIdioma.Id = IdiomaBuscado.IdIdioma;
                    respAltaIdioma.Codigo = "400";
                    respAltaIdioma.Mensaje =ex.InnerException.Message;
                    return respAltaIdioma;
                }
            }
        }
        public Idioma FindIdioma(long idIdioma)
        {
            Idioma RespFindIdioma = IdiomaData.FindIdioma(idIdioma);
            if (RespFindIdioma == null)
            {
                RespFindIdioma = new Idioma();
                RespFindIdioma.IdIdioma = -1;
            }
            return RespFindIdioma;
        }
        public List<Idioma> FindAllIdioma()
        {
            List<Idioma> ResIdiomaRet = IdiomaData.FindAllIdioma();
            return ResIdiomaRet;
        }
    }
}