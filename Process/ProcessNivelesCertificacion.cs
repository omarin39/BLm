using APIRest.DataModels;
using APIRest.Helpers;
using APIRest.Models;
using APIRest.Models.Request;
using APIRest.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Controllers.Process
{
    public class ProcessNivelesCertificacion
    {
        private ResponseNivelesCertificacion ResponseWS = new();
        public DataNivelesCertificacion NivelesCertificacionData = new();
        public ResponseGral AddNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            try
            {
                NivelesCertificacion logNewRegistro = new();
                logNewRegistro.DescNivelCertificacion = NivelesCertificacion.desc_nivel_certificacion;
                long respNewUSR = NivelesCertificacionData.AddNivelesCertificacion(logNewRegistro);
                if(respNewUSR >0)
                {
                    respAltaNivelesCertificacion.Id = respNewUSR;
                    respAltaNivelesCertificacion.Codigo = "200";
                    return respAltaNivelesCertificacion;
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
        public ResponseGral UpdateNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            var nivelesCertificacionBuscado = FindNivelesCertificacion(NivelesCertificacion.Id);
            if(nivelesCertificacionBuscado==null){
                 return respAltaNivelesCertificacion;
            }else{
                try
                {
                    nivelesCertificacionBuscado.DescNivelCertificacion = NivelesCertificacion.desc_nivel_certificacion;
                    var respNewNivelesCertificacion = NivelesCertificacionData.UpdateNivelesCertificacion(nivelesCertificacionBuscado);
                    if (respNewNivelesCertificacion > 0)
                    {
                        respAltaNivelesCertificacion.Id = nivelesCertificacionBuscado.IdNivelCertificacion;
                        respAltaNivelesCertificacion.Codigo = "200";
                        return respAltaNivelesCertificacion;
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
        public NivelesCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            NivelesCertificacion respAltaNivelesCertificacion = NivelesCertificacionData.FindNivelesCertificacion(idNivelesCertificacion);
            if (respAltaNivelesCertificacion == null)
            {
                respAltaNivelesCertificacion.IdNivelCertificacion = -1;
            }
            return respAltaNivelesCertificacion;
        }
        public List<NivelesCertificacion> FindAllNivelesCertificacion()
        {
            List<NivelesCertificacion> resNivelesCertificacionRet = NivelesCertificacionData.FindAllNivelesCertificacion();
            return resNivelesCertificacionRet;
        }
    }
}