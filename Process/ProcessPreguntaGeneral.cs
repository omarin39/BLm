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
    public class ProcessPreguntaGeneral
    {       
        public DataPreguntaPtGeneral PreguntaGeneralData = new();
        public ResponseGral AddPreguntaGeneral(RequestPreguntaGeneral PreguntaGeneral, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();
            try
            {
                PreguntaPtGeneral logNewRegistro = new();
                logNewRegistro.Pregunta = PreguntaGeneral.Pregunta;
                logNewRegistro.Respuesta = PreguntaGeneral.Respuesta;
                logNewRegistro.Orden = PreguntaGeneral.Orden;
                logNewRegistro.IdiomaIdIdioma = PreguntaGeneral.IdiomaIdIdioma;
                logNewRegistro.NivelCertificacionIdNivelCertificacion = PreguntaGeneral.NivelCertificacionIdNivelCertificacion;
                long respNewUSR = PreguntaGeneralData.AddPregunta(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPreguntaGeneral.Id = respNewUSR;
                    respAltaPreguntaGeneral.Codigo = "200";
                    respAltaPreguntaGeneral.Mensaje = "OK";
                    return respAltaPreguntaGeneral;
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

        public ResponseGral UpdatePreguntaGeneral( RequestPreguntaGeneral PreguntaGeneral, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();

  


            var PreguntaGeneralBuscado = FindPreguntaGeneral(PreguntaGeneral.IdPreguntaPt);
            if (PreguntaGeneralBuscado == null)
            {
                return respAltaPreguntaGeneral;
            }
            else if (PreguntaGeneralBuscado.IdPreguntaPt == -1)
            {
                respAltaPreguntaGeneral.Id = PreguntaGeneral.IdPreguntaPt;
                respAltaPreguntaGeneral.Codigo = "400";
                respAltaPreguntaGeneral.Mensaje = "Not found";
                return respAltaPreguntaGeneral;
            }
            else
            {
                try
                {

                    PreguntaGeneralBuscado.Pregunta = PreguntaGeneral.Pregunta;
                    PreguntaGeneralBuscado.Respuesta = PreguntaGeneral.Respuesta;
                    PreguntaGeneralBuscado.Orden = PreguntaGeneral.Orden;
                    PreguntaGeneralBuscado.IdiomaIdIdioma = PreguntaGeneral.IdiomaIdIdioma;
                    PreguntaGeneralBuscado.NivelCertificacionIdNivelCertificacion = PreguntaGeneral.NivelCertificacionIdNivelCertificacion;


                    var respNewPreguntaGeneral = PreguntaGeneralData.UpdatePregunta(PreguntaGeneralBuscado,ip);
                    if (respNewPreguntaGeneral > 0)
                    {
                        respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaPt;
                        respAltaPreguntaGeneral.Codigo = "200";
                        respAltaPreguntaGeneral.Mensaje = "OK";
                        return respAltaPreguntaGeneral;
                    }
                    else
                    {
                        respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaPt;
                        respAltaPreguntaGeneral.Codigo = "400";
                        respAltaPreguntaGeneral.Mensaje = "Record not found";
                        return respAltaPreguntaGeneral;
                    }
                }
                catch (Exception ex)
                {
                    respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaPt;
                    respAltaPreguntaGeneral.Codigo = "400";
                    respAltaPreguntaGeneral.Mensaje =ex.InnerException.Message;
                    return respAltaPreguntaGeneral;
                }
            }
        }
        public PreguntaPtGeneral FindPreguntaGeneral(long PreguntaGeneral){
            PreguntaPtGeneral respAltaPreguntaGeneral = PreguntaGeneralData.FindPregunta(PreguntaGeneral);
            if (respAltaPreguntaGeneral == null)
            {
                respAltaPreguntaGeneral = new PreguntaPtGeneral();
                respAltaPreguntaGeneral.IdPreguntaPt = -1;
            }
            return respAltaPreguntaGeneral;
        }
    


        public List<PreguntaPtGeneral> FindAllPreguntaGeneral()
        {
            List<PreguntaPtGeneral> resPreguntaGeneralRet = PreguntaGeneralData.FindAllPreguntas();
            return resPreguntaGeneralRet;
        }


    }
}
