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
    public class ProcessPreguntaMaquina
    {       
        public DataPreguntaMaquina entityData = new();
        public ResponseGral AddPreguntaMaquina(RequestPreguntaMaquina req, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                PreguntaMaquina newRecord = new();
                newRecord.Pregunta = req.Pregunta;
                newRecord.Respuesta = req.Respuesta;
                newRecord.Orden = req.Orden;
                newRecord.MaquinaIdMaquina = req.MaquinaIdMaquina;
                newRecord.IdiomaIdIdioma = req.IdiomaIdIdioma;
                newRecord.NivelCertificacionIdNivelCertificacion = req.NivelCertificacionIdNivelCertificacion;
                newRecord.Activo = req.Activo;


                long respNewUSR = entityData.AddPreguntaMaquina(newRecord, ip);
                if(respNewUSR >0)
                {
                    respAltaPieza.Id = respNewUSR;
                    respAltaPieza.Codigo = "200";
                    respAltaPieza.Mensaje = "OK";
                    return respAltaPieza;
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

     

        public PreguntaMaquina findPreguntaMaquinaPorId(long id)
        {
            PreguntaMaquina respAltaPieza = entityData.findPreguntaMaquinaIdMaquina(id);
            if (respAltaPieza == null)
            {
                respAltaPieza = new PreguntaMaquina();
                respAltaPieza.IdPreguntaMaquina = -1;
            }
            return respAltaPieza;
        }

        public List<PreguntaMaquina> FindPreguntaPorIdMaquina(long id)
        {
            return entityData.FindPreguntaPorIdMaquina(id);
        }



        public List<PreguntaMaquina> FindAllPreguntaMaquina()
    {
        List<PreguntaMaquina> resPiezaRet = entityData.FindAllPreguntaMaquina();
        return resPiezaRet;
    }

        public ResponseGral UpdatePreguntaMaquina(RequestPreguntaMaquina req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = findPreguntaMaquinaPorId(req.IdPreguntaMaquina);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdPreguntaMaquina == -1)
            {
                response.Id = req.IdPreguntaMaquina;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.IdPreguntaMaquina = req.IdPreguntaMaquina;
                    itemBuscado.Pregunta = req.Pregunta;
                    itemBuscado.Respuesta = req.Respuesta;
                    itemBuscado.Orden = req.Orden;
                    itemBuscado.MaquinaIdMaquina = req.MaquinaIdMaquina;
                    itemBuscado.IdiomaIdIdioma = req.IdiomaIdIdioma;
                    itemBuscado.NivelCertificacionIdNivelCertificacion = req.NivelCertificacionIdNivelCertificacion;
                    itemBuscado.Activo = req.Activo;



                    var respNewItem = entityData.UpdatePreguntaMaquina(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdPreguntaMaquina;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdPreguntaMaquina;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdPreguntaMaquina;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }


    }
}
