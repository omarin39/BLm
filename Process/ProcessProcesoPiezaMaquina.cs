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
    public class ProcessProcesoPiezaMaquina
    {
        public DataProcesoPiezaMaquina entityData = new();

        public ResponseGral AddProcesoPiezaMaquina(RequestProcesoPiezaMaquina ProcesoPieza, String ip)
        {
            ResponseGral respAltaProcesoPieza = new();
            try
            {
                ProcesoPiezaMaquina logNewRegistro = new();
                logNewRegistro.PiezaIdPieza = ProcesoPieza.PiezaIdPieza;
                logNewRegistro.MaquinaProcesoIdMaquinaProceso = ProcesoPieza.MaquinaProcesoIdMaquinaProceso;
                logNewRegistro.UsaPreguntaEstandar = ProcesoPieza.UsaPreguntaEstandar;
                logNewRegistro.Activo = ProcesoPieza.Activo;
                long respNewUSR = entityData.AddProcesoPiezaMaquina(logNewRegistro, ip);
                if (respNewUSR > 0)
                {
                    respAltaProcesoPieza.Id = respNewUSR;
                    respAltaProcesoPieza.Codigo = "200";
                    respAltaProcesoPieza.Mensaje = "OK";
                    return respAltaProcesoPieza;
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

        public ResponseGral UpdateProcesoPiezaMaquina(RequestProcesoPiezaMaquina req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = FindProcesoPiezaById(req.IdProcesoPiezaMaquina);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdProcesoPiezaMaquina == -1)
            {
                response.Id = req.IdProcesoPiezaMaquina;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.UsaPreguntaEstandar = req.UsaPreguntaEstandar;
                    itemBuscado.Activo = req.Activo;
                    var respNewItem = entityData.UpdateProcesoPiezaMaquina(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdProcesoPiezaMaquina;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdProcesoPiezaMaquina;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdProcesoPiezaMaquina;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public List<ResponseProcesoPiezaMaquina> FindAllProcesoPiezaMaquina()
        {
            List<ResponseProcesoPiezaMaquina> resPreguntaProcesoRet = entityData.findAllProcesoPiezaMaquina();
            return resPreguntaProcesoRet;
        }

        public ProcesoPiezaMaquina FindProcesoPiezaById(long id)
        {
            ProcesoPiezaMaquina respProcesoPieza = entityData.findProcesoPiezaMaquinaIdProcesoPieza(id);
            if (respProcesoPieza == null)
            {
                respProcesoPieza = new ProcesoPiezaMaquina();
                respProcesoPieza.IdProcesoPiezaMaquina = -1;
            }
            return respProcesoPieza;
        }


        public List<ResponseProcesoPiezaMaquina> FindProcesoPiezaoByMaquinaProceso(long id)
        {
            List<ResponseProcesoPiezaMaquina> respProcesoPiezaRet = entityData.findProcesoPiezaMaquinaIdMaquinaProceso(id);
            return respProcesoPiezaRet;
        }
    }
}
