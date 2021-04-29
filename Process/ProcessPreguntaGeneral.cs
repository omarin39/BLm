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
    public class ProcessPreguntaGeneral
    {       
        public DataPreguntaPtGeneral PreguntaGeneralData = new();
        public ResponseGral AddPreguntaGeneral(RequestPreguntaGeneral PreguntaGeneral, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();
            try
            {
                PreguntasPtGenerale logNewRegistro = new();
                logNewRegistro.Pregunta = PreguntaGeneral.pregunta;
                logNewRegistro.Respuesta = PreguntaGeneral.respuesta;
                logNewRegistro.Orden = PreguntaGeneral.orden;
                logNewRegistro.IdiomaIdIdioma = PreguntaGeneral.idIdioma;
                logNewRegistro.NivelesCertificacionIdNivelCertificacion = PreguntaGeneral.idNivelCertificcion;
                long respNewUSR = PreguntaGeneralData.AddPregunta(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPreguntaGeneral.Id = respNewUSR;
                    respAltaPreguntaGeneral.Codigo = "200";
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

  


            var PreguntaGeneralBuscado = FindPreguntaGeneral(PreguntaGeneral.pregunta);
            if (PreguntaGeneralBuscado == null)
            {
                return respAltaPreguntaGeneral;
            }
            else
            {
                try
                {

                    PreguntaGeneralBuscado.Pregunta = PreguntaGeneral.pregunta;
                    PreguntaGeneralBuscado.Respuesta = PreguntaGeneral.respuesta;
                    PreguntaGeneralBuscado.Orden = PreguntaGeneral.orden;
                    PreguntaGeneralBuscado.IdiomaIdIdioma = PreguntaGeneral.idIdioma;
                    PreguntaGeneralBuscado.NivelesCertificacionIdNivelCertificacion = PreguntaGeneral.idNivelCertificcion;


                    var respNewPreguntaGeneral = PreguntaGeneralData.UpdatePregunta(PreguntaGeneralBuscado,ip);
                    if (respNewPreguntaGeneral > 0)
                    {
                        respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaPt;
                        respAltaPreguntaGeneral.Codigo = "200";
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
        }
        public PreguntasPtGenerale FindPreguntaGeneral(String PreguntaGeneral){
            PreguntasPtGenerale respAltaPreguntaGeneral = PreguntaGeneralData.FindPregunta(PreguntaGeneral);
            if (respAltaPreguntaGeneral == null)
            {
                respAltaPreguntaGeneral.IdPreguntaPt = -1;
            }
            return respAltaPreguntaGeneral;
        }
    


        public List<PreguntasPtGenerale> FindAllPreguntaGeneral()
        {
            List<PreguntasPtGenerale> resPreguntaGeneralRet = PreguntaGeneralData.FindAllPreguntas();
            return resPreguntaGeneralRet;
        }


    }
}
