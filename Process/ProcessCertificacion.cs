using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessCertificacion
    {       
        public DataCertificacion CertificacionData = new();
        public ResponseGral AddCertificacion(RequestCertificacion Certificacion)
        {
            ResponseGral respAltaCertificacion = new();
            try
            {
                Certificacione logNewRegistro = new();
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
                long respNewUSR = CertificacionData.AddCertificacion(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaCertificacion.Id = respNewUSR;
                    respAltaCertificacion.Codigo = "200";
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

        public ResponseGral UpdateCertificacion( RequestCertificacion Certificacion)
        {
            ResponseGral respAltaCertificacion = new();
            var CertificacionBuscado = FindCertificacion(Certificacion.idCertificacion);
            if (CertificacionBuscado == null)
            {
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

                    var respNewCertificacion = CertificacionData.UpdateCertificacion(CertificacionBuscado);
                    if (respNewCertificacion > 0)
                    {
                        respAltaCertificacion.Id = CertificacionBuscado.IdCertificacion;
                        respAltaCertificacion.Codigo = "200";
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
        }
        public Certificacione FindCertificacion(long idCertificacion){
            Certificacione respAltaCertificacion = CertificacionData.FindCertificacion(idCertificacion);
            if (respAltaCertificacion == null)
            {
                respAltaCertificacion.IdCertificacion = -1;
            }
            return respAltaCertificacion;
        }
    


    public List<Certificacione> FindAllCertificacion()
    {
        List<Certificacione> resCertificacionRet = CertificacionData.FindAllCertificacions();
        return resCertificacionRet;
    }


}
}
