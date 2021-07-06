using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessNivelesCertificacion
    {
        public DataNivelesCertificacion NivelesCertificacionData = new();
        public ResponseGral AddNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion, String ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            try
            {
                if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(1, NivelesCertificacion) == false)
                {
                    if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(2, NivelesCertificacion) == false)
                    {
                        if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(3, NivelesCertificacion) == false)
                        {
                            NivelCertificacion logNewRegistro = new();
                            logNewRegistro.NombreNivelCertificacion = NivelesCertificacion.NombreNivelCertificacion;
                            logNewRegistro.DescripcionNivelCertificacion = NivelesCertificacion.DescripcionNivelCertificacion;
                            logNewRegistro.DificultadNivelCertificacion = NivelesCertificacion.DificultadNivelCertificacion;
                            logNewRegistro.Color = NivelesCertificacion.Color;
                            logNewRegistro.Activo = NivelesCertificacion.Activo;

                            long respNewUSR = NivelesCertificacionData.AddNivelesCertificacion(logNewRegistro, ip);
                            if (respNewUSR > 0)
                            {
                                respAltaNivelesCertificacion.Id = respNewUSR;
                                respAltaNivelesCertificacion.Codigo = "200";
                                respAltaNivelesCertificacion.Mensaje = "OK";
                                return respAltaNivelesCertificacion;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            respAltaNivelesCertificacion.Id = -3;
                            respAltaNivelesCertificacion.Codigo = "-";
                            respAltaNivelesCertificacion.Mensaje = "Color Duplicado";
                            return respAltaNivelesCertificacion;

                        }

                       
                    }
                    else
                    {
                        respAltaNivelesCertificacion.Id = -2;
                        respAltaNivelesCertificacion.Codigo = "-2";
                        respAltaNivelesCertificacion.Mensaje = "Dificultad Duplicado";
                        return respAltaNivelesCertificacion;

                    }
                }
                else
                {
                    respAltaNivelesCertificacion.Id = -1;
                    respAltaNivelesCertificacion.Codigo = "-1";
                    respAltaNivelesCertificacion.Mensaje = "Nombre Duplicado";
                    return respAltaNivelesCertificacion;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResponseGral UpdateNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion, String ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            var nivelesCertificacionBuscado = FindNivelesCertificacion(NivelesCertificacion.IdNivelCertificacion);
            if(nivelesCertificacionBuscado==null){
                 return respAltaNivelesCertificacion;
            }
            else if (nivelesCertificacionBuscado.IdNivelCertificacion == -1)
            {
                respAltaNivelesCertificacion.Id = NivelesCertificacion.IdNivelCertificacion;
                respAltaNivelesCertificacion.Codigo = "400";
                respAltaNivelesCertificacion.Mensaje = "Not found";
                return respAltaNivelesCertificacion;
            }
            else
            {
                try
                {

                    if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(1, NivelesCertificacion) == false)
                    {
                        if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(2, NivelesCertificacion) == false)
                        {
                            if (NivelesCertificacionData.FindNivelCertificacionsDuplicidad(3, NivelesCertificacion) == false)
                            {
                                nivelesCertificacionBuscado.NombreNivelCertificacion = NivelesCertificacion.NombreNivelCertificacion;
                                nivelesCertificacionBuscado.DescripcionNivelCertificacion = NivelesCertificacion.DescripcionNivelCertificacion;
                                nivelesCertificacionBuscado.DificultadNivelCertificacion = NivelesCertificacion.DificultadNivelCertificacion;
                                nivelesCertificacionBuscado.Color = NivelesCertificacion.Color;
                                nivelesCertificacionBuscado.Activo = NivelesCertificacion.Activo;



                                var respNewNivelesCertificacion = NivelesCertificacionData.UpdateNivelesCertificacion(nivelesCertificacionBuscado, ip);
                                if (respNewNivelesCertificacion > 0)
                                {
                                    respAltaNivelesCertificacion.Id = nivelesCertificacionBuscado.IdNivelCertificacion;
                                    respAltaNivelesCertificacion.Codigo = "200";
                                    respAltaNivelesCertificacion.Mensaje = "OK";
                                    return respAltaNivelesCertificacion;
                                }
                                else
                                {
                                    respAltaNivelesCertificacion.Id = nivelesCertificacionBuscado.IdNivelCertificacion;
                                    respAltaNivelesCertificacion.Codigo = "400";
                                    respAltaNivelesCertificacion.Mensaje = "Record not found";
                                    return respAltaNivelesCertificacion;
                                }
                            }
                            else
                            {
                                respAltaNivelesCertificacion.Id = -3;
                                respAltaNivelesCertificacion.Codigo = "-";
                                respAltaNivelesCertificacion.Mensaje = "Color Duplicado";
                                return respAltaNivelesCertificacion;

                            }

                           
                        }
                        else
                        {
                            respAltaNivelesCertificacion.Id = -2;
                            respAltaNivelesCertificacion.Codigo = "-2";
                            respAltaNivelesCertificacion.Mensaje = "Dificultad Duplicado";
                            return respAltaNivelesCertificacion;

                        }
                    }
                    else
                    {
                        respAltaNivelesCertificacion.Id = -1;
                        respAltaNivelesCertificacion.Codigo = "-1";
                        respAltaNivelesCertificacion.Mensaje = "Nombre Duplicado";
                        return respAltaNivelesCertificacion;

                    }
                }
                catch (Exception ex)
                {
                    respAltaNivelesCertificacion.Id = nivelesCertificacionBuscado.IdNivelCertificacion;
                    respAltaNivelesCertificacion.Codigo = "400";
                    respAltaNivelesCertificacion.Mensaje = ex.InnerException.Message;
                    return respAltaNivelesCertificacion;
                }
            }
        }
        public NivelCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            NivelCertificacion respAltaNivelesCertificacion = NivelesCertificacionData.FindNivelesCertificacion(idNivelesCertificacion);
            if (respAltaNivelesCertificacion == null)
            {
                respAltaNivelesCertificacion = new NivelCertificacion();
                respAltaNivelesCertificacion.IdNivelCertificacion = -1;
            }
            return respAltaNivelesCertificacion;
        }

        public List<NivelCertificacion> FindNivelesCertificacionAsignaCapacitacion(RequestNivelesCertificacionAsignaCapacitacion NivelFindAsigCapacita)
        {
            return NivelesCertificacionData.FindNivelesCertificacionAsignaCapacitacion(NivelFindAsigCapacita);
        }
        public List<NivelCertificacion> FindAllNivelesCertificacion()
        {
            List<NivelCertificacion> resNivelesCertificacionRet = NivelesCertificacionData.FindAllNivelesCertificacion();
            return resNivelesCertificacionRet;
        }
    }
}