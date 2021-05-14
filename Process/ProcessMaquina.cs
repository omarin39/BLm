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
    public class ProcessMaquina
    {       
        public DataMaquina entityData = new();
        public ResponseGral AddMaquina(RequestMaquina req, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                Maquina newRecord = new();
                newRecord.Nombre = req.Nombre;
                newRecord.Descripcion = req.Descripcion;
                newRecord.Modelo = req.Modelo;
                newRecord.MaquinaPt = req.MaquinaPt;
                newRecord.CantidadAccesoMultiple = req.CantidadAccesoMultiple;
                newRecord.FabricanteIdFabricante = req.FabricanteIdFabricante;
                newRecord.TipoAccesoIdTipoAcceso = req.TipoAccesoIdTipoAcceso;
                newRecord.Activo = req.Activo;
                
                long respNewUSR = entityData.AddMaquina(newRecord, ip);
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

        public ResponseGral UpdateMaquina(RequestMaquina req, String ip)
        {
            ResponseGral response = new();

            //var itemBuscado = findMaquinaPorId(req.IdMaquina);
            var itemBuscado = FindOnlyMaquinaPorId(req.IdMaquina);
            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdMaquina == -1)
            {
                response.Id = req.IdMaquina;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {
                    var maq = new Maquina
                    {
                        IdMaquina = itemBuscado.IdMaquina,
                        Nombre = req.Nombre,
                        Descripcion = req.Descripcion,
                        Modelo = req.Modelo,
                        MaquinaPt = req.MaquinaPt,
                        CantidadAccesoMultiple = req.CantidadAccesoMultiple,
                        FabricanteIdFabricante = req.FabricanteIdFabricante,
                        TipoAccesoIdTipoAcceso = req.TipoAccesoIdTipoAcceso
                    };




                    var respNewItem = entityData.UpdateMaquina(maq, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdMaquina;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdMaquina;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdMaquina;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public VwMaquinaPregunta findMaquinaPorId(long id)
        {
            VwMaquinaPregunta respBuscado = entityData.findPiezaPorIdPieza(id);
            if (respBuscado == null)
            {
                respBuscado = new VwMaquinaPregunta();
                respBuscado.IdMaquina = -1;
            }
            return respBuscado;
        }

        public Maquina FindOnlyMaquinaPorId(long id)
        {
            Maquina respBuscado = entityData.FindMaquina(id);
            if (respBuscado == null)
            {
                respBuscado = new Maquina();
                respBuscado.IdMaquina = -1;
            }
          return respBuscado;
        }

        

        public List<VwMaquinaPregunta> FindAllMaquina()
    {
        List<VwMaquinaPregunta> resPiezaRet = entityData.FindAllMaquina();
        return resPiezaRet;
    }


}
}
