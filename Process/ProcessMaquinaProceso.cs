using System;
using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessMaquinaProceso
    {
        public DataMaquinaProceso entityData = new();

        public ResponseGral AddMaquinaProceso(RequestMaquinaProceso req, String ip)
        {
            ResponseGral respAltaMaquinaProceso = new();
            try
            {
                MaquinaProceso newRecord = new();
                newRecord.MaquinaIdMaquina = req.MaquinaIdMaquina;
                newRecord.ProcesoIdProceso = req.ProcesoIdProceso;
                newRecord.Activo = req.Activo;

                long respNewMaqPro = entityData.AddMaquinaProceso(newRecord, ip);
                if (respNewMaqPro > 0)
                {
                    respAltaMaquinaProceso.Id = respNewMaqPro;
                    respAltaMaquinaProceso.Codigo = "200";
                    respAltaMaquinaProceso.Mensaje = "OK";
                    return respAltaMaquinaProceso;
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

        public ResponseGral UpdateMaquinaProceso(RequestMaquinaProceso req, String ip)
        {
            ResponseGral response = new();
            var itemBuscado = FindMaquinaProcesoByID(req.IdMaquinaProceso);
            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdMaquinaProceso == -1)
            {
                response.Id = req.IdMaquinaProceso;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {
                    var maqProc = new MaquinaProceso
                    {
                        IdMaquinaProceso = itemBuscado.IdMaquinaProceso,
                        MaquinaIdMaquina = itemBuscado.MaquinaIdMaquina,
                        ProcesoIdProceso = itemBuscado.ProcesoIdProceso,
                        Activo = req.Activo
                    };

                    var respNewItem = entityData.UpdateMaquinaProceso(maqProc, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdMaquinaProceso;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdMaquinaProceso;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdMaquinaProceso;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public List<MaquinaProceso> FindAllMaquinaProceso()
        {
            List<MaquinaProceso> resMaquinaProcesoRet = entityData.findAllMaquinasProceso();
            return resMaquinaProcesoRet;
        }
        public MaquinaProceso FindMaquinaProcesoByID(long MaquinaProceso)
        {
            MaquinaProceso resMaquinaProceso = entityData.FindMaquinaProcesoByID(MaquinaProceso);
            if (resMaquinaProceso == null)
            {
                resMaquinaProceso = new MaquinaProceso();
                resMaquinaProceso.IdMaquinaProceso = -1;
            }
            return resMaquinaProceso;
        }

        public List<ResponseMaquinaProceso> FindMaquinaProceso(long Maquina)
        {
            List<ResponseMaquinaProceso> resMaquinaProceso = entityData.FindMaquinaProceso(Maquina);
            return resMaquinaProceso;
        }
    }

    
}
