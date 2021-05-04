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
        private ResponseNivelesCertificacion ResponseWS = new();
        public DataNivelesCertificacion NivelesCertificacionData = new();
        public ResponseGral AddNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion, String ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            try
            {
                NivelCertificacion logNewRegistro = new();
                logNewRegistro.NombreNivelCertificacion = NivelesCertificacion.NombreNivelCertificacion;
                logNewRegistro.DescripcionNivelCertificacion = NivelesCertificacion.DescripcionNivelCertificacion;
                logNewRegistro.DificultadNivelCertificacion = NivelesCertificacion.DificultadNivelCertificacion;
                logNewRegistro.Color = NivelesCertificacion.Color;
                logNewRegistro.Activo = NivelesCertificacion.Activo;
             



                long respNewUSR = NivelesCertificacionData.AddNivelesCertificacion(logNewRegistro,ip);
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
        public ResponseGral UpdateNivelesCertificacion(RequestNivelesCertificacion NivelesCertificacion, String ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            var nivelesCertificacionBuscado = FindNivelesCertificacion(NivelesCertificacion.IdNivelCertificacion);
            if(nivelesCertificacionBuscado==null){
                 return respAltaNivelesCertificacion;
            }else{
                try
                {
                    
                    nivelesCertificacionBuscado.NombreNivelCertificacion = NivelesCertificacion.NombreNivelCertificacion;
                    nivelesCertificacionBuscado.DescripcionNivelCertificacion = NivelesCertificacion.DescripcionNivelCertificacion;
                    nivelesCertificacionBuscado.DificultadNivelCertificacion = NivelesCertificacion.DificultadNivelCertificacion;
                    nivelesCertificacionBuscado.Color = NivelesCertificacion.Color;
                    nivelesCertificacionBuscado.Activo = NivelesCertificacion.Activo;



                    var respNewNivelesCertificacion = NivelesCertificacionData.UpdateNivelesCertificacion(nivelesCertificacionBuscado,ip);
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
        public NivelCertificacion FindNivelesCertificacion(long idNivelesCertificacion)
        {
            NivelCertificacion respAltaNivelesCertificacion = NivelesCertificacionData.FindNivelesCertificacion(idNivelesCertificacion);
            if (respAltaNivelesCertificacion == null)
            {
                respAltaNivelesCertificacion.IdNivelCertificacion = -1;
            }
            return respAltaNivelesCertificacion;
        }
        public List<NivelCertificacion> FindAllNivelesCertificacion()
        {
            List<NivelCertificacion> resNivelesCertificacionRet = NivelesCertificacionData.FindAllNivelesCertificacion();
            return resNivelesCertificacionRet;
        }
    }
}