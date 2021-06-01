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
        public DataPreguntaGeneral PreguntaGeneralData = new();
        public ResponseGral AddPreguntaGeneral(RequestPreguntaGeneral PreguntaGeneral, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();
            try
            {
                PreguntaGeneral logNewRegistro = new();
                logNewRegistro.Pregunta = PreguntaGeneral.Pregunta;
                logNewRegistro.Respuesta = PreguntaGeneral.Respuesta;
                logNewRegistro.Orden = PreguntaGeneral.Orden;
                logNewRegistro.IdiomaIdIdioma = PreguntaGeneral.IdiomaIdIdioma;
                logNewRegistro.TipoPreguntaIdTipoPregunta = PreguntaGeneral.TipoPreguntaIdTipoPregunta;
                logNewRegistro.NivelCertificacionIdNivelCertificacion = PreguntaGeneral.NivelCertificacionIdNivelCertificacion;
                logNewRegistro.Activo = PreguntaGeneral.Activo;
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

  


            var PreguntaGeneralBuscado = FindPreguntaGeneral(PreguntaGeneral.IdPreguntaGeneral);
            if (PreguntaGeneralBuscado == null)
            {
                return respAltaPreguntaGeneral;
            }
            else if (PreguntaGeneralBuscado.IdPreguntaGeneral == -1)
            {
                respAltaPreguntaGeneral.Id = PreguntaGeneral.IdPreguntaGeneral;
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
                    PreguntaGeneralBuscado.TipoPreguntaIdTipoPregunta = PreguntaGeneral.TipoPreguntaIdTipoPregunta;
                    PreguntaGeneralBuscado.Activo = PreguntaGeneral.Activo;


                    var respNewPreguntaGeneral = PreguntaGeneralData.UpdatePregunta(PreguntaGeneralBuscado,ip);
                    if (respNewPreguntaGeneral > 0)
                    {
                        respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaGeneral;
                        respAltaPreguntaGeneral.Codigo = "200";
                        respAltaPreguntaGeneral.Mensaje = "OK";
                        return respAltaPreguntaGeneral;
                    }
                    else
                    {
                        respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaGeneral;
                        respAltaPreguntaGeneral.Codigo = "400";
                        respAltaPreguntaGeneral.Mensaje = "Record not found";
                        return respAltaPreguntaGeneral;
                    }
                }
                catch (Exception ex)
                {
                    respAltaPreguntaGeneral.Id = PreguntaGeneralBuscado.IdPreguntaGeneral;
                    respAltaPreguntaGeneral.Codigo = "400";
                    respAltaPreguntaGeneral.Mensaje =ex.InnerException.Message;
                    return respAltaPreguntaGeneral;
                }
            }
        }
        public PreguntaGeneral FindPreguntaGeneral(long id){
            PreguntaGeneral respAltaPreguntaGeneral = PreguntaGeneralData.FindPregunta(id);
            if (respAltaPreguntaGeneral == null)
            {
                respAltaPreguntaGeneral = new PreguntaGeneral();
                respAltaPreguntaGeneral.IdPreguntaGeneral = -1;
            }
            return respAltaPreguntaGeneral;
        }

        public List<PreguntaGeneral> FindPreguntaGeneralByTipo(long tipo)
        {
            List<PreguntaGeneral> resPreguntaGeneralRet = PreguntaGeneralData.FindPreguntasByTipo(tipo);
            return resPreguntaGeneralRet;
           
        }



        public List<PreguntaGeneral> FindAllPreguntaGeneral()
        {
            List<PreguntaGeneral> resPreguntaGeneralRet = PreguntaGeneralData.FindAllPreguntas();
            return resPreguntaGeneralRet;
        }


    }
}
