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
    public class ProcessPiezaCliente
    {       
        public DataPiezaCliente entityData = new();
        public ResponseGral AddPiezaCliente(RequestPiezaCliente req, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                PiezaCliente newRecord = new();
                newRecord.ClienteIdCliente = req.ClienteIdCliente;
                newRecord.PiezaIdPieza = req.PiezaIdPieza;
                newRecord.Activo = req.Activo;
                
                long respNewUSR = entityData.AddPiezaCliente(newRecord, ip);
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

        public ResponseGral UpdatePiezasCliente(RequestPiezaCliente req, String ip)
        {
            ResponseGral respUpdatePiezaCliente = new();
            try
            {
                PiezaCliente UpdateRecord = new();
                UpdateRecord.Id = req.Id;
                UpdateRecord.ClienteIdCliente = req.ClienteIdCliente;
                UpdateRecord.PiezaIdPieza = req.PiezaIdPieza;
                UpdateRecord.Activo = req.Activo;

                long respNewUSR = entityData.UpdatePiezaCliente(UpdateRecord, ip);
                if (respNewUSR > 0)
                {
                    respUpdatePiezaCliente.Id = respNewUSR;
                    respUpdatePiezaCliente.Codigo = "200";
                    respUpdatePiezaCliente.Mensaje = "OK";
                    return respUpdatePiezaCliente;
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



        public List<VwPiezaCliente> FindClientesPorIdPieza(long id)
        {
            List<VwPiezaCliente> respAltaPieza = entityData.FindClientesPorIdPieza(id);
            if (respAltaPieza == null)
            {
                respAltaPieza = new ();
            }
            return respAltaPieza;
        }



        public List<VwPiezaCliente> FindAllPiezaCliente()
    {
        List<VwPiezaCliente> resPiezaRet = entityData.FindAllPiezaCliente();
        return resPiezaRet;
    }


}
}
