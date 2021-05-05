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
    public class ProcessTipoDocumento
    {       
        public DataTipoDocumento TipoDocumentoData = new();
        public ResponseGral AddTipoDocumento(RequestTipoDocumento TipoDocumento, String ip)
        {
            ResponseGral respAltaTipoDocumento = new();
            try
            {
                TipoDocumento logNewRegistro = new();
                logNewRegistro.Descripcion = TipoDocumento.Descripcion;
                logNewRegistro.TipoDocumento1 = TipoDocumento.TipoDocumento1;

                long respNewUSR = TipoDocumentoData.AddTipoDocumento(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaTipoDocumento.Id = respNewUSR;
                    respAltaTipoDocumento.Codigo = "200";
                    respAltaTipoDocumento.Mensaje = "OK";
                    return respAltaTipoDocumento;
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

        public ResponseGral UpdateTipoDocumento( RequestTipoDocumento TipoDocumento, String ip)
        {
            ResponseGral respAltaTipoDocumento = new();

            //Valida si una plata tiene naves asociadas
           /* if (TipoDocumento.Activo == false)
            {
                DataNave naveData = new();
                List<Nave> resNavesRet = naveData.FindAllNavesPorTipoDocumento(TipoDocumento.IdTipoDocumento);
                if (resNavesRet.Count > 0)
                {
                    respAltaTipoDocumento.Id = TipoDocumento.IdTipoDocumento;
                    respAltaTipoDocumento.Codigo = "503";
                    respAltaTipoDocumento.Mensaje = "La TipoDocumento no puede desactivarse, por que tiene " + resNavesRet.Count.ToString() + " naves asociadas.";
                    return respAltaTipoDocumento;
                }
            }*/



            var TipoDocumentoBuscado = FindTipoDocumento(TipoDocumento.TipoDocumento1);
            if (TipoDocumentoBuscado == null)
            {
                return respAltaTipoDocumento;
            }
            else if (TipoDocumentoBuscado.Id == -1)
            {
                respAltaTipoDocumento.Id = TipoDocumento.Id;
                respAltaTipoDocumento.Codigo = "400";
                respAltaTipoDocumento.Mensaje = "Not found";
                return respAltaTipoDocumento;
            }
            else
            {
                try
                {

                    var tipoDocumentoBuscado = new TipoDocumento
                    {
                        Id = TipoDocumento.Id,
                        Descripcion = TipoDocumento.Descripcion,
                        TipoDocumento1 = TipoDocumento.TipoDocumento1,
                      
                    };



                    var respNewTipoDocumento = TipoDocumentoData.UpdateTipoDocumento(tipoDocumentoBuscado, ip);
                    if (respNewTipoDocumento > 0)
                    {
                        respAltaTipoDocumento.Id = TipoDocumentoBuscado.Id;
                        respAltaTipoDocumento.Codigo = "200";
                        respAltaTipoDocumento.Mensaje = "OK";
                        return respAltaTipoDocumento;
                    }
                    else
                    {
                        respAltaTipoDocumento.Id = TipoDocumentoBuscado.Id;
                        respAltaTipoDocumento.Codigo = "400";
                        respAltaTipoDocumento.Mensaje = "Record not found";
                        return respAltaTipoDocumento;
                    }
                }
                catch (Exception ex)
                {
                    respAltaTipoDocumento.Id = TipoDocumentoBuscado.Id;
                    respAltaTipoDocumento.Codigo = "400";
                    respAltaTipoDocumento.Mensaje = ex.InnerException.Message;
                    return respAltaTipoDocumento;
                }
            }
        }
        public TipoDocumento FindTipoDocumento(string tipoDocumento)
        {
            TipoDocumento respAltaTipoDocumento = TipoDocumentoData.FindTipoDocumento(tipoDocumento);
            if (respAltaTipoDocumento == null)
            {
                respAltaTipoDocumento = new TipoDocumento();
                respAltaTipoDocumento.Id = -1;
            }

           /* var result = new ResponseTipoDocumento
            {
                IdTipoDocumento = respAltaTipoDocumento.IdTipoDocumento,
                IdTipoDocumentoExterno = respAltaTipoDocumento.IdTipoDocumentoExterno,
                Acronimo = respAltaTipoDocumento.Acronimo,
                Activo = (bool)respAltaTipoDocumento.Activo,
                TipoDocumento= respAltaTipoDocumento.TipoDocumento,
                Naves = respAltaTipoDocumento.Naves.Count,

            };


            return result;*/
            return respAltaTipoDocumento;
        }
    


        public List<TipoDocumento> FindAllTipoDocumento()
        {
            List<TipoDocumento> resTipoDocumentoRet = TipoDocumentoData.FindAllTipoDocumento();
             return resTipoDocumentoRet;
           /* var result = resTipoDocumentoRet.Select((TipoDocumento, i) =>
                      new ResponseTipoDocumento
                      {
                          IdTipoDocumento = TipoDocumento.IdTipoDocumento,
                          IdTipoDocumentoExterno = TipoDocumento.IdTipoDocumentoExterno,
                          Acronimo = TipoDocumento.Acronimo,
                          TipoDocumento = TipoDocumento.TipoDocumento,
                          Activo = (bool)TipoDocumento.Activo,
                          Naves = TipoDocumento.Naves.Count,
                      }).ToList();


            return result;*/
        }


    }
}
