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
    public class ProcessPieza
    {       
        public DataPieza PiezaData = new();
        public ResponseGral AddPieza(RequestPieza Pieza, String ip)
        {
            ResponseGral respAltaPieza = new();
            try
            {
                if (PiezaData.ValidaClaveExistente(Pieza) == false)
                {
                    Pieza logNewRegistro = new();
                    logNewRegistro.Nombre = Pieza.Nombre;
                    logNewRegistro.Descripcion = Pieza.Descripcion;
                    logNewRegistro.Activo = Pieza.Activo;
                    logNewRegistro.NumeroParte = Pieza.NumeroParte;
                    long respNewUSR = PiezaData.AddPieza(logNewRegistro, ip);
                    if (respNewUSR > 0)
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
                else
                {
                    respAltaPieza.Id = -1;
                    respAltaPieza.Codigo = "-1";
                    respAltaPieza.Mensaje =  "Numero de parte Duplicado";
                    return respAltaPieza;

                }

                }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdatePieza( RequestPieza Pieza, String ip)
        {
            ResponseGral respAltaPieza = new();
            if (PiezaData.ValidaClaveExistente(Pieza) == false)
            {
                var PiezaBuscado = FindPieza(Pieza.Nombre);
                if (PiezaBuscado == null)
                {
                    return respAltaPieza;
                }
                else if (PiezaBuscado.IdPieza == -1)
                {
                    respAltaPieza.Id = Pieza.IdPieza;
                    respAltaPieza.Codigo = "400";
                    respAltaPieza.Mensaje = "Not found";
                    return respAltaPieza;
                }
                else
                {
                    try
                    {
                        PiezaBuscado.Nombre = Pieza.Nombre;
                        PiezaBuscado.Descripcion = Pieza.Descripcion;
                        PiezaBuscado.Activo = Pieza.Activo;
                        PiezaBuscado.NumeroParte = Pieza.NumeroParte;
                        var respNewPieza = PiezaData.UpdatePieza(PiezaBuscado, ip);
                        if (respNewPieza > 0)
                        {
                            respAltaPieza.Id = PiezaBuscado.IdPieza;
                            respAltaPieza.Codigo = "200";
                            respAltaPieza.Mensaje = "OK";
                            return respAltaPieza;
                        }
                        else
                        {
                            respAltaPieza.Id = PiezaBuscado.IdPieza;
                            respAltaPieza.Codigo = "400";
                            respAltaPieza.Mensaje = "Record not found";
                            return respAltaPieza;
                        }
                    }
                    catch (Exception ex)
                    {
                        respAltaPieza.Id = PiezaBuscado.IdPieza;
                        respAltaPieza.Codigo = "400";
                        respAltaPieza.Mensaje = ex.InnerException.Message;
                        return respAltaPieza;
                    }
                }
            }
            else
            {
                respAltaPieza.Id = -1;
                respAltaPieza.Codigo = "-1";
                respAltaPieza.Mensaje = "Numero de parte Duplicado";
                return respAltaPieza;

            }
        }
        public Pieza FindPieza(String Pieza){
            Pieza respAltaPieza = PiezaData.FindPieza(Pieza);
            if (respAltaPieza == null)
            {
                respAltaPieza = new Pieza();
                respAltaPieza.IdPieza = -1;
            }
            return respAltaPieza;
        }

        public VwPiezasMultimedia FindPiezaPorIdPieza(long idPieza)
        {
            VwPiezasMultimedia respAltaPieza = PiezaData.FindPiezaPorId(idPieza);
            if (respAltaPieza == null)
            {
                respAltaPieza = new VwPiezasMultimedia();
                respAltaPieza.IdPieza = -1;
            }
            return respAltaPieza;
        }



        public List<VwPiezasMultimedia> FindAllPieza()
    {
        List<VwPiezasMultimedia> resPiezaRet = PiezaData.FindAllPiezas();
        return resPiezaRet;
    }


}
}
