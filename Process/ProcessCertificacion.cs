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
    public class ProcessCertificacion
    {       
        public DataCertificacion CertificacionData = new();
        public ResponseGral AddCertificacion(RequestCertificacion Certificacion, String ip)
        {
            ResponseGral respAltaCertificacion = new();
            try
            {
                Certificacion logNewRegistro = new();
                logNewRegistro.FechaEntrenamiento = Certificacion.fechaEntrenamiento;
                logNewRegistro.FechaCertificacion = Certificacion.fechaCertificacion;
                logNewRegistro.IdCertificador = Certificacion.idCertificador;
                logNewRegistro.TokenCertificador = Certificacion.tokenCertificador;
                logNewRegistro.FechaCertificador = Certificacion.fechaCertificador;
                logNewRegistro.IdMentor = Certificacion.idMentor;
                logNewRegistro.TokenMentor = Certificacion.tokenMentor;
                logNewRegistro.FechaMentor = Certificacion.fechaMentor;
                logNewRegistro.IdResponsable = Certificacion.idResponsable;
                logNewRegistro.TokenResponsable = Certificacion.tokenResponsable;
                logNewRegistro.FechaResponsable = Certificacion.fechaResponsable;
                logNewRegistro.Resultado = Certificacion.resultado;
                logNewRegistro.Activo = Certificacion.Activo;
                long respNewUSR = CertificacionData.AddCertificacion(logNewRegistro,ip);
                if(respNewUSR >0)
                {
                    respAltaCertificacion.Id = respNewUSR;
                    respAltaCertificacion.Codigo = "200";
                    respAltaCertificacion.Mensaje = "OK";
                    return respAltaCertificacion;
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

        public ResponseGral UpdateCertificacion( RequestCertificacion Certificacion, String ip)
        {
            ResponseGral respAltaCertificacion = new();
            var CertificacionBuscado = FindCertificacion(Certificacion.idCertificacion);
            if (CertificacionBuscado == null)
            {
                return respAltaCertificacion;
            }
            else if (CertificacionBuscado.IdCertificacion == -1)
            {
                respAltaCertificacion.Id = Certificacion.idCertificacion;
                respAltaCertificacion.Codigo = "400";
                respAltaCertificacion.Mensaje = "Not found";
                return respAltaCertificacion;
            }
            else
            {
                try
                {
                

                    CertificacionBuscado.FechaEntrenamiento = Certificacion.fechaEntrenamiento;
                    CertificacionBuscado.FechaCertificacion = Certificacion.fechaCertificacion;
                    CertificacionBuscado.IdCertificador = Certificacion.idCertificador;
                    CertificacionBuscado.TokenCertificador = Certificacion.tokenCertificador;
                    CertificacionBuscado.FechaCertificador = Certificacion.fechaCertificador;
                    CertificacionBuscado.IdMentor = Certificacion.idMentor;
                    CertificacionBuscado.TokenMentor = Certificacion.tokenMentor;
                    CertificacionBuscado.FechaMentor = Certificacion.fechaMentor;
                    CertificacionBuscado.IdResponsable = Certificacion.idResponsable;
                    CertificacionBuscado.TokenResponsable = Certificacion.tokenResponsable;
                    CertificacionBuscado.FechaResponsable = Certificacion.fechaResponsable;
                    CertificacionBuscado.Resultado = Certificacion.resultado;
                    CertificacionBuscado.Activo = Certificacion.Activo;

                    var respNewCertificacion = CertificacionData.UpdateCertificacion(CertificacionBuscado,ip);
                    if (respNewCertificacion > 0)
                    {
                        respAltaCertificacion.Id = CertificacionBuscado.IdCertificacion;
                        respAltaCertificacion.Mensaje = "OK";
                        respAltaCertificacion.Codigo = "200";
                        return respAltaCertificacion;
                    }
                    else
                    {
                        respAltaCertificacion.Id = CertificacionBuscado.IdCertificacion;
                        respAltaCertificacion.Codigo = "400";
                        respAltaCertificacion.Mensaje = "Record not found";
                        return respAltaCertificacion;
                    }
                }
                catch (Exception ex)
                {
                    respAltaCertificacion.Id = CertificacionBuscado.IdCertificacion;
                    respAltaCertificacion.Codigo = "400";
                    respAltaCertificacion.Mensaje =ex.InnerException.Message;
                    return respAltaCertificacion;
                }
            }
        }
        public Certificacion FindCertificacion(long idCertificacion){
            Certificacion respAltaCertificacion = CertificacionData.FindCertificacion(idCertificacion);
            if (respAltaCertificacion == null)
            {
                respAltaCertificacion = new Certificacion();
                respAltaCertificacion.IdCertificacion = -1;
            }
            return respAltaCertificacion;
        }
    


    public List<Certificacion> FindAllCertificacion()
    {
        List<Certificacion> resCertificacionRet = CertificacionData.FindAllCertificacions();
        return resCertificacionRet;
    }


}
}
