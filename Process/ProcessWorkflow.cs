using APIRestV2.DataModels;
using APIRestV2.Helpers;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Controllers.Process
{
    public class ProcessWorkflow
    {
        public DataWorkFlow entityData = new();

        public ResponseGral AddWorkflow(RequestWorkflow workflow, String ip)
        {
            ResponseGral respAltaWorkflow = new();
            try
            {
                Workflow logNewRegistro = new();
               
                logNewRegistro.Orden = workflow.Orden;
                logNewRegistro.Tiempo = workflow.Tiempo;
                logNewRegistro.PiezaIdPieza = workflow.PiezaIdPieza;
                logNewRegistro.ProcesoIdProceso = workflow.ProcesoIdProceso;
                logNewRegistro.Activo = workflow.Activo;

                long respNewUSR = entityData.AddWorkflow(logNewRegistro, ip);
                if (respNewUSR > 0)
                {
                    respAltaWorkflow.Id = respNewUSR;
                    respAltaWorkflow.Codigo = "200";
                    respAltaWorkflow.Mensaje = "OK";
                    return respAltaWorkflow;
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

        public Workflow FindWorflowById(long id)
        {
            Workflow respWorkflow = entityData.findWorflowIdWorkflow(id);
            if (respWorkflow == null)
            {
                respWorkflow = new Workflow();
                respWorkflow.IdWorkFlow = -1;
            }
            return respWorkflow;
        }

        public ResponseGral UpdateWorkflow(RequestWorkflow req, String ip)
        {
            ResponseGral response = new();

            var itemBuscado = FindWorflowById(req.IdWorkFlow);

            if (itemBuscado == null)
            {
                return response;
            }
            else if (itemBuscado.IdWorkFlow == -1)
            {
                response.Id = req.IdWorkFlow;
                response.Codigo = "400";
                response.Mensaje = "Not found";
                return response;
            }
            else
            {
                try
                {

                    itemBuscado.IdWorkFlow = req.IdWorkFlow;
                    itemBuscado.Tiempo = req.Tiempo;
                    itemBuscado.Orden = req.Orden;
                    itemBuscado.PiezaIdPieza = req.PiezaIdPieza;
                    itemBuscado.ProcesoIdProceso = req.ProcesoIdProceso;
                    itemBuscado.Activo = req.Activo;

                    var respNewItem = entityData.UpdateWorkflow(itemBuscado, ip);
                    if (respNewItem > 0)
                    {
                        response.Id = req.IdWorkFlow;
                        response.Codigo = "200";
                        response.Mensaje = "OK";
                        return response;
                    }
                    else
                    {
                        response.Id = req.IdWorkFlow;
                        response.Codigo = "400";
                        response.Mensaje = "Record not found";
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response.Id = req.IdWorkFlow;
                    response.Codigo = "400";
                    response.Mensaje = ex.InnerException.Message;
                    return response;
                }
            }
        }

        public List<Workflow> FindWorkflowByPieza(long id)
        {
            List<Workflow> respWorkflowRet = entityData.FindWorkflowPieza(id);
            return respWorkflowRet;
        }
    }
}
