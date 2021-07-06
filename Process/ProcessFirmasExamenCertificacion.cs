using APIRestV2.Controllers.Process;
using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Process
{
    public class ProcessFirmasExamenCertificacion
    {
        public DataFirmasExamenCertificacion FirmasExamenCertificacionData = new();
        public ProcessExamenCertificacion PorcTem = new();
        private ProcessCertificacion ProcCertificacion = new();
        private ProcessCapacitacionEmpleado procCapacitacionEmpleado = new();
        public ResponseGral AddFirmasExamenCertificacion(RequestFirmasExamenCertificacion FirmaExamen, String ip)
        {
            ResponseGral respAltaFabricante = new();
            try
            {
                FirmasExamenCertificacion logNewfirma = new();
                logNewfirma.IdExamenCertificacion = FirmaExamen.IdExamenCertificacion;
                logNewfirma.IdTipoFirma= FirmaExamen.IdTipoFirma;
                logNewfirma.FechaFirma = DateTime.Now;
                logNewfirma.Activo = true;
                long respNewFirma = FirmasExamenCertificacionData.AddFirmasExamenCertificacion(logNewfirma, ip);
                if (respNewFirma > 0)
                {
                    if (FirmaExamen.IdTipoFirma == 1)
                    {
                        PorcTem.UpdateExamenCertificaFirmaExamen(FirmaExamen.IdExamenCertificacion, ip);
                        ProcCertificacion.AddCertificacionFirmaExamen(FirmaExamen.IdExamenCertificacion, ip);
                        procCapacitacionEmpleado.AddCapacitacionEmpleadoFirmaExamen(FirmaExamen.IdExamenCertificacion, ip);
                    }
                    respAltaFabricante.Id = respNewFirma;
                    respAltaFabricante.Codigo = "200";
                    respAltaFabricante.Mensaje = "OK";
                    return respAltaFabricante;
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

        public List<ResponseFirmasPendientesExamenCertifica> FindFirmasPendientes()
        {
            List<ResponseFirmasPendientesExamenCertifica> resFabricanteRet = FirmasExamenCertificacionData.FindFirmasPendientes();
            return resFabricanteRet;
        }

        
    }
}
