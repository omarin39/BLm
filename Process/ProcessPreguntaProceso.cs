using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessPreguntaProceso
    {
        public DataPreguntaProceso entityData = new();


        public ResponseGral AddPreguntaProceso(RequestPreguntaProceso PreguntaProceso, String ip)
        {
            ResponseGral respAltaPreguntaGeneral = new();
            try
            {
                PreguntaProceso logNewRegistro = new();
                logNewRegistro.Pregunta = PreguntaProceso.Pregunta;
                logNewRegistro.Respuesta = PreguntaProceso.Respuesta;
                logNewRegistro.Orden = PreguntaProceso.Orden;
                logNewRegistro.IdiomaIdIdioma = PreguntaProceso.IdiomaIdIdioma;
                logNewRegistro.MaquinaProcesoIdMaquinaProceso = PreguntaProceso.MaquinaProcesoIdMaquinaProceso;
                logNewRegistro.NivelCertificacionIdNivelCertificacion = PreguntaProceso.NivelCertificacionIdNivelCertificacion;
                logNewRegistro.Activo = PreguntaProceso.Activo;
                long respNewUSR = entityData.AddPreguntaProceso(logNewRegistro, ip);
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

        public ResponseGral UpdatePreguntaProceso(RequestPreguntaProceso req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = FindPreguntaProcesoById(req.IdPreguntaProceso);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdPreguntaProceso == -1)
            {
                response.Id = req.IdPreguntaProceso;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.IdPreguntaProceso = req.IdPreguntaProceso;
                    itemBuscado.Pregunta = req.Pregunta;
                    itemBuscado.Respuesta = req.Respuesta;
                    itemBuscado.Orden = req.Orden;
                    itemBuscado.MaquinaProcesoIdMaquinaProceso = req.MaquinaProcesoIdMaquinaProceso;
                    itemBuscado.IdiomaIdIdioma = req.IdiomaIdIdioma;
                    itemBuscado.NivelCertificacionIdNivelCertificacion = req.NivelCertificacionIdNivelCertificacion;
                    itemBuscado.Activo = req.Activo;
                    var respNewItem = entityData.UpdatePreguntaProceso(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdPreguntaProceso;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdPreguntaProceso;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdPreguntaProceso;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public List<PreguntaProceso> FindAllPreguntaProceso()
        {
            List<PreguntaProceso> resPreguntaProcesoRet = entityData.findAllPreguntaProceso();
            return resPreguntaProcesoRet;
        }

        public PreguntaProceso FindPreguntaProcesoById(long id)
        {
            PreguntaProceso respPreguntaProceso = entityData.findPreguntaProcesoIdPreguntaProceso(id);
            if (respPreguntaProceso == null)
            {
                respPreguntaProceso = new PreguntaProceso();
                respPreguntaProceso.IdPreguntaProceso = -1;
            }
            return respPreguntaProceso;
        }


        public List <PreguntaProceso> FindPreguntaProcesoByMaquinaProceso(long id)
        {
            List<PreguntaProceso> respPreguntaProcesoRet = entityData.findPreguntaProcesoIdMaquinaProceso(id);
            return respPreguntaProcesoRet;
        }

        public List<ResponsePreguntasTotalesProcesos> FindGlobalPreguntasIdMaquinaIdNivelCertifica(long IdProceso, string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {
            List<ResponsePreguntasTotalesProcesos> respPreguntaProcesoRet = entityData.FindGlobalPreguntasIdMaquinaIdNivelCertifica(IdProceso, IdMaquina, IdNivelCertifica, IdIdioma);
            return respPreguntaProcesoRet;
        }

        


    }
}
