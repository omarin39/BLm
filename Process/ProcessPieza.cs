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
                    respAltaPieza.Mensaje = "Numero de parte Duplicado";
                    return respAltaPieza;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ResponseGral UpdatePieza(RequestPieza Pieza, String ip)
        {
            ResponseGral respAltaPieza = new();
            if (PiezaData.ValidaClaveExistente(Pieza) == false)
            {
                var PiezaBuscado = FindPiezaToIdPieza(Pieza.IdPieza);
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
        public Pieza FindPieza(string Pieza)
        {
            Pieza respAltaPieza = PiezaData.FindPieza(Pieza);
            if (respAltaPieza == null)
            {
                respAltaPieza = new Pieza();
                respAltaPieza.IdPieza = -1;
            }
            return respAltaPieza;
        }
        //public List<Pieza> FindPiezaCertificacion(string Pieza)
        //{
        //    return PiezaData.FindPiezaCertificacion(Pieza);

        //}

        public Pieza FindPiezaCertificacion(string Pieza)
        {
            return PiezaData.FindPiezaCertificacion(Pieza);

        }

        public List<VwPiezasasignacapacitacion> FindPiezaAsignaCapacitacion(long IdEmp)
        {
            return PiezaData.FindPiezaAsignaCapacitacion(IdEmp);

        }

        public List<VwPiezaprocesoasignacapacitacion> FindProcesosdePiezaAsignaCapacitacion(long IdPieza)
        {
            return PiezaData.FindProcesosdePiezaAsignaCapacitacion(IdPieza);

        }

        public List<VwPiezaprocesomaquinaasignacapacitacion> FindMaquinadeProcesosdePiezaAsignaCapacitacion(long IdProceso)
        {
            return PiezaData.FindMaquinadeProcesosdePiezaAsignaCapacitacion(IdProceso);

        }


        public Pieza FindPiezaToIdPieza(long IdPieza)
        {
            Pieza respAltaPieza = PiezaData.FindPiezaToId(IdPieza);
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

        internal List<ResponsePieza> FindPiezaAutoComplete(string param)
        {
            List<Pieza> resPiezaRet = PiezaData.FindPiezaAutoComplete(param);

            var result = resPiezaRet.Select((pza, i) =>
                    new ResponsePieza
                    {
                        IdPieza = pza.IdPieza,
                        Nombre = pza.Nombre,
                        // Descripcion=pza.Descripcion,
                        NumeroParte = pza.NumeroParte,
                        // Activo=pza.Activo
                    }).ToList();
            return result;
        }

        public List<VwPiezasMultimedia> FindAllPieza()
        {
            List<VwPiezasMultimedia> resPiezaRet = PiezaData.FindAllPiezas();
            return resPiezaRet;
        }
    }
}
