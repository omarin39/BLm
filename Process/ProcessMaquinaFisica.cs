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
    public class ProcessMaquinaFisica
    {
        public DataMaquinaFisica entityData = new();
        public ResponseGral AddMaquinaFisica(RequestMaquinaFisica req, String ip)
        {
            ResponseGral respAltaMaquinaFisica = new();
            try
            {
                if (entityData.ValidaNSerieExistente(req.Nserie) == false)
                {
                    MaquinaFisica newRecord = new();
                    newRecord.Nserie = req.Nserie;
                    newRecord.Ubicacion = req.Ubicacion;
                    newRecord.MaquinaPt = req.MaquinaPt;
                    newRecord.MaquinaIdMaquina = req.MaquinaIdMaquina;
                    newRecord.PlantaIdPlanta = req.PlantaIdPlanta;
                    newRecord.NaveIdNave = req.NaveIdNave;
                    newRecord.LineaProduccionIdLineaProduccion = req.LineaProduccionIdLineaProduccion;
                    newRecord.Activo = req.Activo;

                    long respNewMaquinaFisica = entityData.AddMaquinaFisica(newRecord, ip);
                    if (respNewMaquinaFisica > 0)
                    {
                        respAltaMaquinaFisica.Id = respNewMaquinaFisica;
                        respAltaMaquinaFisica.Codigo = "200";
                        respAltaMaquinaFisica.Mensaje = "OK";
                        return respAltaMaquinaFisica;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    respAltaMaquinaFisica.Id = -1;
                    respAltaMaquinaFisica.Codigo = "-1";
                    respAltaMaquinaFisica.Mensaje = "Numero de Serie Duplicado";
                    return respAltaMaquinaFisica;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdateMaquinaFisica(RequestMaquinaFisica req, String ip)
        {
            ResponseGral response = new();

            //var itemBuscado = findMaquinaPorId(req.IdMaquina);
            var itemBuscado = FindOnlyMaquinaPorId(req.IdMaquinaFisica);
            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdMaquinaFisica == -1)
            {
                response.Id = req.IdMaquinaFisica;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {
                    var maq = new MaquinaFisica
                    {
                        IdMaquinaFisica = itemBuscado.IdMaquinaFisica,
                        Nserie = itemBuscado.Nserie,
                        Ubicacion = req.Ubicacion,
                        MaquinaPt = itemBuscado.MaquinaPt,
                        MaquinaIdMaquina = itemBuscado.MaquinaIdMaquina,
                        PlantaIdPlanta = req.PlantaIdPlanta,
                        NaveIdNave = req.NaveIdNave,
                        LineaProduccionIdLineaProduccion = req.LineaProduccionIdLineaProduccion,
                        Activo = req.Activo
                    };

                    var respNewItem = entityData.UpdateMaquinaFisica(maq, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdMaquinaFisica;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdMaquinaFisica;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdMaquinaFisica;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public MaquinaFisica FindOnlyMaquinaPorId(long id)
        {
            MaquinaFisica respBuscado = entityData.findMaquinaFisicaPorIdMaquinaFisica(id);
            if (respBuscado == null)
            {
                respBuscado = new MaquinaFisica();
                respBuscado.IdMaquinaFisica = -1;
            }
            return respBuscado;
        }



        public List<ResponseMaquinaFisica> FindAllMaquinaFisica()
        {
            List<ResponseMaquinaFisica> resMaquinaRet = entityData.FindAllMaquinaFisica();
            return resMaquinaRet;
        }

    }
}
