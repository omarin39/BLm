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
    public class ProcessPreguntaPtGeneral
    {       
        public DataPreguntaPtGeneral PreguntaData = new();
        public ResponseGral AddPregunta(RequestPreguntaPtGeneral Pregunta, String ip)
        {
            ResponseGral respAltaPregunta = new();
            try
            {
                PreguntasPtGenerale logNewRegistro = new();
                logNewRegistro.Pregunta = Pregunta.pregunta;
                logNewRegistro.Respuesta = Pregunta.respuesta;
                logNewRegistro.Orden = Pregunta.orden;
                logNewRegistro.IdiomaIdIdioma = Pregunta.idiomaIdIdioma;
                logNewRegistro.NivelesCertificacionIdNivelCertificacion = Pregunta.idNiveCertificacion;
                long respNewUSR = PreguntaData.AddPregunta(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaPregunta.Id = respNewUSR;
                    respAltaPregunta.Codigo = "200";
                    return respAltaPregunta;
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

        public ResponseGral UpdatePregunta(RequestPreguntaPtGeneral Pregunta, String ip)
        {
            ResponseGral respAltaPregunta = new();
            var PreguntaBuscado = FindPregunta(Pregunta.pregunta);
            if (PreguntaBuscado == null)
            {
                return respAltaPregunta;
            }
            else
            {
                try
                {
       

                    PreguntaBuscado.Pregunta = Pregunta.pregunta;
                    PreguntaBuscado.Respuesta = Pregunta.respuesta;
                    PreguntaBuscado.Orden = Pregunta.orden;
                    PreguntaBuscado.IdiomaIdIdioma = Pregunta.idiomaIdIdioma;
                    PreguntaBuscado.NivelesCertificacionIdNivelCertificacion = Pregunta.idNiveCertificacion;


                    var respNewPregunta = PreguntaData.UpdatePregunta(PreguntaBuscado,ip);
                    if (respNewPregunta > 0)
                    {
                        respAltaPregunta.Id = PreguntaBuscado.IdPreguntaPt;
                        respAltaPregunta.Codigo = "200";
                        return respAltaPregunta;
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
        public PreguntasPtGenerale FindPregunta(String Pregunta){
            PreguntasPtGenerale respAltaPregunta = PreguntaData.FindPregunta(Pregunta);
            if (respAltaPregunta == null)
            {
                respAltaPregunta.IdPreguntaPt = -1;
            }
            return respAltaPregunta;
        }
    


    public List<PreguntasPtGenerale> FindAllPregunta()
    {
        List<PreguntasPtGenerale> resPreguntaRet = PreguntaData.FindAllPreguntas();
        return resPreguntaRet;
    }


}
}
