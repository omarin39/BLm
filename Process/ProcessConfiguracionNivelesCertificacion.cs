using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessConfiguracionNivelesCertificacion
    {
        public DataConfiguracionNivelesCertificacion ConfigNivelesCertificacionData = new();
        public DataPerfil PerfilDataTemp = new();
        public List<ResponseConfiguracionNivelesCertificacion> FindAllConfiguracionNivelesCertificacion()
        {
            List<ResponseConfiguracionNivelesCertificacion> ResConfigNivelCert = new();
            List<ConfiguracionNivelCertificacion> ConfigNivelesCertificacionGral = ConfigNivelesCertificacionData.FindAllConfiguracionNivelesCertificacion();
            foreach (var item in ConfigNivelesCertificacionGral)
            {                
                ResConfigNivelCert.Add(CreaResponseConfigNivelCert(item));
            }
            return ResConfigNivelCert;

        }
        public ResponseConfiguracionNivelesCertificacion FindById(long Id)
        {
            ResponseConfiguracionNivelesCertificacion resutalfin = new();
            ConfiguracionNivelCertificacion ConfigNivelesCertificacionGral = ConfigNivelesCertificacionData.FindById(Id);
            if (ConfigNivelesCertificacionGral != null)
            {
                resutalfin = CreaResponseConfigNivelCert(ConfigNivelesCertificacionGral);
            }
            return resutalfin;
        }

        public ResponseConfiguracionNivelesCertificacion FindByIdNivelCertifica(long Id)
        {
            ResponseConfiguracionNivelesCertificacion resutalfin = new();
            ConfiguracionNivelCertificacion ConfigNivelesCertificacionGral = ConfigNivelesCertificacionData.FindByIdNivelCertificacion(Id);
            if (ConfigNivelesCertificacionGral != null)
            {
                resutalfin = CreaResponseConfigNivelCert(ConfigNivelesCertificacionGral);
            }
            return resutalfin;

        }

        public ResponseGral AddConfiguraNivelesCertificacion(RequestConfiguracionNivelesCertificacion ConfNivelesCertificacion, string ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            try
            {
                string PerfilFirman = "";
                string PerfilExaminan = "";
                ConfiguracionNivelCertificacion NewConfigNivelCert = new();
                NewConfigNivelCert.IdNivelCertificacion = ConfNivelesCertificacion.IdNivelCertificacion;
                NewConfigNivelCert.PlazoCertificaOperNuevo = ConfNivelesCertificacion.PlazoCertificaOperNuevo;
                NewConfigNivelCert.ReintentosOperNuevo = ConfNivelesCertificacion.ReintentosOperNuevo;
                NewConfigNivelCert.PlazoReCertificaOperNuevo = ConfNivelesCertificacion.PlazoReCertificaOperNuevo;
                NewConfigNivelCert.PlazoCertificaOperAntiguo = ConfNivelesCertificacion.PlazoCertificaOperAntiguo;
                NewConfigNivelCert.ReintentosOperAntiguo = ConfNivelesCertificacion.ReintentosOperAntiguo;
                NewConfigNivelCert.PlazoReCertificaOperAntiguo = ConfNivelesCertificacion.PlazoReCertificaOperAntiguo;
                for (int i = 0; i < ConfNivelesCertificacion.IdsPerfilFirman.Count; i++)
                {
                    if (i < (ConfNivelesCertificacion.IdsPerfilFirman.Count - 1))
                    {
                        PerfilFirman += ConfNivelesCertificacion.IdsPerfilFirman[i].Id + ",";
                    }
                    else
                    {
                        PerfilFirman += ConfNivelesCertificacion.IdsPerfilFirman[i].Id;
                    }

                }
                NewConfigNivelCert.IdsPerfilFirman = PerfilFirman;
                for (int i = 0; i < ConfNivelesCertificacion.IdsPerfilExaminan.Count; i++)
                {
                    if (i < (ConfNivelesCertificacion.IdsPerfilExaminan.Count - 1))
                    {
                        PerfilExaminan += ConfNivelesCertificacion.IdsPerfilExaminan[i].Id + ",";
                    }
                    else
                    {
                        PerfilExaminan += ConfNivelesCertificacion.IdsPerfilExaminan[i].Id;
                    }

                }
                NewConfigNivelCert.IdsPerfilExaminan = PerfilExaminan;




                long respNewCNF = ConfigNivelesCertificacionData.AddConfiguracionNivelesCertificacion(NewConfigNivelCert, ip);
                if (respNewCNF > 0)
                {
                    respAltaNivelesCertificacion.Id = respNewCNF;
                    respAltaNivelesCertificacion.Codigo = "200";
                    respAltaNivelesCertificacion.Mensaje = "OK";
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

        public ResponseGral UpdateConfiguraNivelesCertificacion(RequestConfiguracionNivelesCertificacion ConfNivelesCertificacion, string ip)
        {
            ResponseGral respAltaNivelesCertificacion = new();
            ConfiguracionNivelCertificacion ConfignivelesCertificacionBuscado = ConfigNivelesCertificacionData.FindByIdNivelCertificacion(ConfNivelesCertificacion.IdConfiguraNivelCertifica);
            if (ConfignivelesCertificacionBuscado == null)
            {
                return respAltaNivelesCertificacion;
            }
            else
            {
                try
                {
                    string PerfilFirman = "";
                    string PerfilExaminan = "";
                    ConfignivelesCertificacionBuscado.PlazoCertificaOperNuevo = ConfNivelesCertificacion.PlazoCertificaOperNuevo;
                    ConfignivelesCertificacionBuscado.ReintentosOperNuevo = ConfNivelesCertificacion.ReintentosOperNuevo;
                    ConfignivelesCertificacionBuscado.PlazoReCertificaOperNuevo = ConfNivelesCertificacion.PlazoReCertificaOperNuevo;
                    ConfignivelesCertificacionBuscado.PlazoCertificaOperAntiguo = ConfNivelesCertificacion.PlazoCertificaOperAntiguo;
                    ConfignivelesCertificacionBuscado.ReintentosOperAntiguo = ConfNivelesCertificacion.ReintentosOperAntiguo;
                    ConfignivelesCertificacionBuscado.PlazoReCertificaOperAntiguo = ConfNivelesCertificacion.PlazoReCertificaOperAntiguo;
                    for (int i = 0; i < ConfNivelesCertificacion.IdsPerfilFirman.Count; i++)
                    {
                        if (i < (ConfNivelesCertificacion.IdsPerfilFirman.Count - 1))
                        {
                            PerfilFirman += ConfNivelesCertificacion.IdsPerfilFirman[i].Id + ",";
                        }
                        else
                        {
                            PerfilFirman += ConfNivelesCertificacion.IdsPerfilFirman[i].Id;
                        }

                    }
                    ConfignivelesCertificacionBuscado.IdsPerfilFirman = PerfilFirman;
                    for (int i = 0; i < ConfNivelesCertificacion.IdsPerfilExaminan.Count; i++)
                    {
                        if (i < (ConfNivelesCertificacion.IdsPerfilExaminan.Count - 1))
                        {
                            PerfilExaminan += ConfNivelesCertificacion.IdsPerfilExaminan[i].Id + ",";
                        }
                        else
                        {
                            PerfilExaminan += ConfNivelesCertificacion.IdsPerfilExaminan[i].Id;
                        }

                    }
                    ConfignivelesCertificacionBuscado.IdsPerfilExaminan = PerfilExaminan;
                    var respNewNivelesCertificacion = ConfigNivelesCertificacionData.UpdateConfiguracionNivelesCertificacion(ConfignivelesCertificacionBuscado, ip);
                    if (respNewNivelesCertificacion > 0)
                    {
                        respAltaNivelesCertificacion.Id = ConfignivelesCertificacionBuscado.IdNivelCertificacion;
                        respAltaNivelesCertificacion.Codigo = "200";
                        respAltaNivelesCertificacion.Mensaje = "OK";
                        return respAltaNivelesCertificacion;
                    }
                    else
                    {
                        respAltaNivelesCertificacion.Id = ConfignivelesCertificacionBuscado.IdNivelCertificacion;
                        respAltaNivelesCertificacion.Codigo = "400";
                        respAltaNivelesCertificacion.Mensaje = "Record not found";
                        return respAltaNivelesCertificacion;
                    }
                }
                catch (Exception ex)
                {
                    respAltaNivelesCertificacion.Id = ConfignivelesCertificacionBuscado.IdNivelCertificacion;
                    respAltaNivelesCertificacion.Codigo = "400";
                    respAltaNivelesCertificacion.Mensaje = ex.InnerException.Message;
                    return respAltaNivelesCertificacion;
                }
            }
        }

        public ResponseConfiguracionNivelesCertificacion CreaResponseConfigNivelCert(ConfiguracionNivelCertificacion item)
        {
            string[] PerfilesFirma;
            string[] PerfilesExamina;
            ResponseConfiguracionNivelesCertificacion ItemAllReg = new();
            ItemAllReg.IdConfiguraNivelCertifica = item.IdConfiguraNivelCertifica;
            ItemAllReg.IdNivelCertificacion = item.IdNivelCertificacion;
            ItemAllReg.PlazoCertificaOperNuevo = item.PlazoCertificaOperNuevo;
            ItemAllReg.ReintentosOperNuevo = item.ReintentosOperNuevo;
            ItemAllReg.PlazoReCertificaOperNuevo = item.PlazoReCertificaOperNuevo;
            ItemAllReg.PlazoCertificaOperAntiguo = item.PlazoCertificaOperAntiguo;
            ItemAllReg.ReintentosOperAntiguo = item.ReintentosOperAntiguo;
            ItemAllReg.PlazoReCertificaOperAntiguo = item.PlazoReCertificaOperAntiguo;
            PerfilesFirma = item.IdsPerfilFirman.Split(",");
            List<Perfil> Perfiltmp = PerfilDataTemp.FindAllPerfilTemp();
            ItemAllReg.IdsPerfilFirman = new();
            foreach (var itemPerfilesFirma in PerfilesFirma)
            {
                foreach (var itemPerfil in Perfiltmp)
                {
                    if (int.Parse(itemPerfilesFirma) == itemPerfil.Id)
                    {

                        ItemAllReg.IdsPerfilFirman.Add(itemPerfil);
                    }

                }
            }
            PerfilesExamina = item.IdsPerfilExaminan.Split(",");
            ItemAllReg.IdsPerfilExaminan = new();
            foreach (var itemPerfilesExamina in PerfilesExamina)
            {
                foreach (var itemPerfil in Perfiltmp)
                {
                    if (int.Parse(itemPerfilesExamina) == itemPerfil.Id)
                    {
                        ItemAllReg.IdsPerfilExaminan.Add(itemPerfil);
                    }
                }
            }
            return ItemAllReg;
        }
    }
}
