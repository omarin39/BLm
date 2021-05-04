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
    public class ProcessPreguntaPtGeneral
    {       
        public DataPreguntaPtGeneral PreguntaData = new();
        public ResponseGral AddPregunta(RequestPreguntaPtGeneral Pregunta, String ip)
        {
            ResponseGral respAltaPregunta = new();
            try
            {
                PreguntaPtGeneral logNewRegistro = new();
                logNewRegistro.Pregunta = Pregunta.Pregunta;
                logNewRegistro.Respuesta = Pregunta.Respuesta;
                logNewRegistro.Orden = Pregunta.Orden;
                logNewRegistro.IdiomaIdIdioma = Pregunta.IdiomaIdIdioma;
                logNewRegistro.NivelCertificacionIdNivelCertificacion = Pregunta.NivelCertificacionIdNivelCertificacion;
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
            var PreguntaBuscado = FindPregunta(Pregunta.IdPreguntaPt);
            if (PreguntaBuscado == null)
            {
                return respAltaPregunta;
            }
            else
            {
                try
                {
       

                    PreguntaBuscado.Pregunta = Pregunta.Pregunta;
                    PreguntaBuscado.Respuesta = Pregunta.Respuesta;
                    PreguntaBuscado.Orden = Pregunta.Orden;
                    PreguntaBuscado.IdiomaIdIdioma = Pregunta.IdiomaIdIdioma;
                    PreguntaBuscado.NivelCertificacionIdNivelCertificacion = Pregunta.NivelCertificacionIdNivelCertificacion;


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
        public PreguntaPtGeneral FindPregunta(long IdPregunta){
            PreguntaPtGeneral respAltaPregunta = PreguntaData.FindPregunta(IdPregunta);
            if (respAltaPregunta == null)
            {
                respAltaPregunta.IdPreguntaPt = -1;
            }
            return respAltaPregunta;
        }
    


    public List<PreguntaPtGeneral> FindAllPregunta()
    {
        List<PreguntaPtGeneral> resPreguntaRet = PreguntaData.FindAllPreguntas();
        return resPreguntaRet;
    }


}
}
