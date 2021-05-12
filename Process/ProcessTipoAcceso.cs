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
    public class ProcessTipoAcceso
    {       
        public DataTipoAcceso entityData = new();
        public ResponseGral AddTipoAcceso(RequestTipoAcceso req, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                TipoAcceso newRecord = new();
                newRecord.DescTipoAcceso = req.DescTipoAcceso;
            
                
                long respNewUSR = entityData.AddTipoAcceso(newRecord, ip);
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

     

        public TipoAcceso findTipoAcceosPorId(long id)
        {
            TipoAcceso respAltaPieza = entityData.findPiezaPorIdPieza(id);
            if (respAltaPieza == null)
            {
                respAltaPieza = new TipoAcceso();
                respAltaPieza.IdTipoAcceso = -1;
            }
            return respAltaPieza;
        }



        public List<TipoAcceso> FindAllTipoAcceso()
    {
        List<TipoAcceso> resPiezaRet = entityData.FindAllTipoAcceso();
        return resPiezaRet;
    }

        public ResponseGral UpdateTipoacceso(RequestTipoAcceso req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = findTipoAcceosPorId(req.IdTipoAcceso);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdTipoAcceso == -1)
            {
                response.Id = req.IdTipoAcceso;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.IdTipoAcceso = req.IdTipoAcceso;
                    itemBuscado.DescTipoAcceso = req.DescTipoAcceso;
             


                    var respNewItem = entityData.UpdateTipoAcceso(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdTipoAcceso;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdTipoAcceso;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdTipoAcceso;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }


    }
}
