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
    public class ProcessPreguntaPieza
    {
        public DataPreguntaPieza entityData = new();


        public ResponseGral AddPreguntaPieza(RequestPreguntaPieza PreguntaPieza, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();
            try
            {
                PreguntaPieza logNewRegistro = new();
                logNewRegistro.Pregunta = PreguntaPieza.Pregunta;
                logNewRegistro.Respuesta = PreguntaPieza.Respuesta;
                logNewRegistro.Orden = PreguntaPieza.Orden;
                logNewRegistro.IdiomaIdIdioma = PreguntaPieza.IdiomaIdIdioma;
                logNewRegistro.ProcesoPiezaMaquinaIdProcesoPiezaMaquina = PreguntaPieza.ProcesoPiezaMaquinaIdProcesoPiezaMaquina;
                logNewRegistro.NivelCertificacionIdNivelCertificacion = PreguntaPieza.NivelCertificacionIdNivelCertificacion;
                logNewRegistro.Activo = PreguntaPieza.Activo;
                long respNewUSR = entityData.AddPreguntaPieza(logNewRegistro, ip);
                if (respNewUSR > 0)
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

        public ResponseGral UpdatePreguntaPieza(RequestPreguntaPieza req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = FindPreguntaPiezaById(req.IdPreguntaPieza);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdPreguntaPieza == -1)
            {
                response.Id = req.IdPreguntaPieza;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.IdPreguntaPieza = req.IdPreguntaPieza;
                    itemBuscado.Pregunta = req.Pregunta;
                    itemBuscado.Respuesta = req.Respuesta;
                    itemBuscado.Orden = req.Orden;
                    itemBuscado.ProcesoPiezaMaquinaIdProcesoPiezaMaquina = req.ProcesoPiezaMaquinaIdProcesoPiezaMaquina;
                    itemBuscado.IdiomaIdIdioma = req.IdiomaIdIdioma;
                    itemBuscado.NivelCertificacionIdNivelCertificacion = req.NivelCertificacionIdNivelCertificacion;
                    itemBuscado.Activo = req.Activo;
                    var respNewItem = entityData.UpdatePreguntaPieza(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdPreguntaPieza;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdPreguntaPieza;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdPreguntaPieza;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public List<PreguntaPieza> FindAllPreguntaPieza()
        {
            List<PreguntaPieza> resPreguntaPiezaRet = entityData.findAllPreguntaPieza();
            return resPreguntaPiezaRet;
        }

        public PreguntaPieza FindPreguntaPiezaById(long id)
        {
            PreguntaPieza respPreguntaPieza = entityData.findPreguntaPiezaIdPreguntaPieza(id);
            if (respPreguntaPieza == null)
            {
                respPreguntaPieza = new PreguntaPieza();
                respPreguntaPieza.IdPreguntaPieza = -1;
            }
            return respPreguntaPieza;
        }


        public List<PreguntaPieza> FindPreguntaPiezaByProcesoPiezaMaquina(long id)
        {
            List<PreguntaPieza> respPreguntaPiezaRet = entityData.findPreguntaPiezaIdProcesoPiezaMaquina(id);
            return respPreguntaPiezaRet;
        }

        public List<ResponsePreguntasTotalesPiezas> FindGlobalPiezaProcesoMaquinaIdNivelCertifica(string IdPieza, long IdProceso, string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {
            List<ResponsePreguntasTotalesPiezas> respPreguntaPiezaRet = entityData.FindGlobalPiezaProcesoMaquinaIdNivelCertifica(IdPieza, IdProceso, IdMaquina, IdNivelCertifica, IdIdioma);
            return respPreguntaPiezaRet;
        }

        
    }
}
