using APIRest.DataModels;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Process
{
    public class ProcessIdioma
    {
        private ResponseIdioma ResponseWS = new();

        public DataIdioma IdiomaData = new();

        // public async Task<List<ProcessLog>> FindAllProcessLogAsync(){
        public ResponseIdioma AddIdioma(RequestIdiomas _idioma)
        {
            ResponseIdioma respAltaIdioma = new();
            try
            {


                Idioma logNewRegistro = new();
                logNewRegistro.CodigoIdioma = _idioma.CodigoIdioma;
                logNewRegistro.Idioma1 = _idioma.Idioma1;
                logNewRegistro.Activo = _idioma.Activo;


                long respNewIdioma = IdiomaData.AddIdioma(logNewRegistro);
                if (respNewIdioma > 0)
                {
                    respAltaIdioma.IdIdioma = respNewIdioma;
                    respAltaIdioma.Codigo = "200";

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

        public ResponseIdioma UpdateIdioma(RequestIdiomas _idioma)
        {
            ResponseIdioma respAltaIdioma = new();

            var IdiomaBuscado = FindIdioma(_idioma.IdIdioma);
            if (IdiomaBuscado == null)
            {
                return respAltaIdioma;
            }
            else
            {
                try
                {

                    IdiomaBuscado.Idioma1 = _idioma.Idioma1;
                    IdiomaBuscado.CodigoIdioma = _idioma.CodigoIdioma;
                    IdiomaBuscado.Activo = _idioma.Activo;



                    var respNewIdioma = IdiomaData.UpdateIdioma(IdiomaBuscado);
                    if (respNewIdioma > 0)
                    {
                        respAltaIdioma.IdIdioma = IdiomaBuscado.IdIdioma;
                        respAltaIdioma.Codigo = "200";

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


        }

        public Idioma FindIdioma(long idIdioma)
        {

            Idioma RespFindIdioma = new();

            RespFindIdioma = IdiomaData.FindIdioma(idIdioma);
            if (RespFindIdioma == null)
            {
                RespFindIdioma.IdIdioma = -1;
            }

            return RespFindIdioma;
        }

        public List<Idioma> FindAllIdioma()
        {
            List<Idioma> ResIdiomaRet = new List<Idioma>();
            ResIdiomaRet = IdiomaData.FindAllIdioma();

            return ResIdiomaRet;
        }
    }
}
