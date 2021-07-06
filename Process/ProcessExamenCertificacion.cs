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
    public class ProcessExamenCertificacion
    {
        public DataExamenDeCertificacion ExamenCertificaData = new();
        public DataResultadoMaquina ExamenCertificaResultadoMaquina = new();
        public DataResultadoProceso ExamenCertificaResultadoProceso = new();
        public DataResultadoPieza ExamenCertificaResultadoPieza = new();
        public DataCapacitacionEmpleado CapacitacionEmp = new();
        public DataResultadoGeneralExamenCertificacionMaquinaProcesoPieza ExamenResultadoGral = new();
        public ResponseGral AddExamenCertifica(RequestExamenDeCertificacion RequestExamenCertifica, string ip)
        {
            ResponseGral respAltaFabricante = new();
            try
            {
                CapacitacionEmpleado capemp = CapacitacionEmp.FindIdCapacitacion(RequestExamenCertifica.IdCapacitacionEmpleado);
                ExamenDeCertificacion EdC = new();
                EdC.IdCapacitacionEmpleado = RequestExamenCertifica.IdCapacitacionEmpleado;
                EdC.TotalFinalExamen = RequestExamenCertifica.TotalFinalExamen;
                EdC.FechaExamen = DateTime.Now;
                EdC.EstadoExamen = RequestExamenCertifica.EstadoExamen;
                EdC.Activo = true;

                long IdRespNewExamenCertifica = ExamenCertificaData.AddExamenCertificacion(EdC, ip);
                if (IdRespNewExamenCertifica > 0)
                {
                    ResultadoMaquina ResMaquina = new();
                    ResMaquina.IdExamenCertificacion = IdRespNewExamenCertifica;
                    ResMaquina.Resultado = RequestExamenCertifica.TotalFinalMaquina;
                    ResMaquina.EstatusResultado = RequestExamenCertifica.TotalDescripcionFinalMaquina;
                    long IdResultadoMaquinaExamenCertifica = ExamenCertificaResultadoMaquina.AddDataResultadoMaquinaExamenCertifica(ResMaquina, ip);

                    ResultadoProceso ResProceso=new();
                    ResProceso.IdExamenCertificacion = IdRespNewExamenCertifica;
                    ResProceso.Resultado = RequestExamenCertifica.TotalFinalProceso;
                    ResProceso.EstatusResultado = RequestExamenCertifica.TotalDescripcionFinalProceso;
                    long IdResultadoProcesoExamenCertifica = ExamenCertificaResultadoProceso.AddDataResultadoProcesoExamenCertifica(ResProceso, ip);

                    ResultadoPieza ResPieza = new();
                    ResPieza.IdExamenCertificacion = IdRespNewExamenCertifica;
                    ResPieza.Resultado = RequestExamenCertifica.TotalFinalPieza;
                    ResPieza.EstatusResultado = RequestExamenCertifica.TotalDescripcionFinalPieza;
                    long IdResultadoPiezaExamenCertifica = ExamenCertificaResultadoPieza.AddDataResultadoPiezaExamenCertifica(ResPieza, ip);

                    

                    foreach (var item in RequestExamenCertifica.DataGlobalPreguntasMaquinaList)
                    {
                        ResultadoGeneralExamenCertificacionMaquinaProcesoPieza ResGral = new();
                        ResGral.IdExamenCertificacion = IdRespNewExamenCertifica;
                        ResGral.IdGlobal = item.IdGlobal;
                        ResGral.IdPregunta = item.IdPregunta;
                        ResGral.Pregunta = item.Pregunta;
                        ResGral.Demuestra = item.Demuestra;
                        ResGral.Reforzar = item.Reforzar;
                        ResGral.NoDemuestra = item.NoDemuestra;
                        ResGral.Resultado = item.Resultado;
                        ResGral.IsGral = item.IsGral;
                        ResGral.IdIdioma = item.IdIdioma;
                        ResGral.TipoPregunta = 1;
                        ResGral.IdNivelCertificacion = item.IdNivelCertificacion;
                        ResGral.Activo = true;
                        ExamenResultadoGral.AddDataResultadoGeneralExamenCertificacionMaquinaProcesoPieza(ResGral,ip);
                    }

                    foreach (var item in RequestExamenCertifica.DataGlobalPreguntasProcesoList)
                    {
                        ResultadoGeneralExamenCertificacionMaquinaProcesoPieza ResGral = new();
                        ResGral.IdExamenCertificacion = IdRespNewExamenCertifica;
                        ResGral.IdGlobal = item.IdGlobal;
                        ResGral.IdPregunta = item.IdPregunta;
                        ResGral.Pregunta = item.Pregunta;
                        ResGral.Demuestra = item.Demuestra;
                        ResGral.Reforzar = item.Reforzar;
                        ResGral.NoDemuestra = item.NoDemuestra;
                        ResGral.Resultado = item.Resultado;
                        ResGral.IsGral = item.IsGral;
                        ResGral.IdIdioma = item.IdIdioma;
                        ResGral.TipoPregunta = 2;
                        ResGral.IdNivelCertificacion = item.IdNivelCertificacion;
                        ResGral.Activo = true;
                        ExamenResultadoGral.AddDataResultadoGeneralExamenCertificacionMaquinaProcesoPieza(ResGral, ip);
                    }

                    foreach (var item in RequestExamenCertifica.DataGlobalPreguntasPiezaList)
                    {
                        ResultadoGeneralExamenCertificacionMaquinaProcesoPieza ResGral = new();
                        ResGral.IdExamenCertificacion = IdRespNewExamenCertifica;
                        ResGral.IdGlobal = item.IdGlobal;
                        ResGral.IdPregunta = item.IdPregunta;
                        ResGral.Pregunta = item.Pregunta;
                        ResGral.Demuestra = item.Demuestra;
                        ResGral.Reforzar = item.Reforzar;
                        ResGral.NoDemuestra = item.NoDemuestra;
                        ResGral.Resultado = item.Resultado;
                        ResGral.IsGral = item.IsGral;
                        ResGral.IdIdioma = item.IdIdioma;
                        ResGral.TipoPregunta = 3;
                        ResGral.IdNivelCertificacion = item.IdNivelCertificacion;
                        ResGral.Activo = true;
                        ExamenResultadoGral.AddDataResultadoGeneralExamenCertificacionMaquinaProcesoPieza(ResGral, ip);
                    }

                    
                    CapacitacionEmpleado UpdEmpleado = new();
                    UpdEmpleado.IdCapacitacion = capemp.IdCapacitacion;
                    UpdEmpleado.IdEmpleado = capemp.IdEmpleado;
                    UpdEmpleado.Concluida = true;
                    UpdEmpleado.FechaFin = capemp.FechaFin;
                    UpdEmpleado.FechaInicio = capemp.FechaInicio;
                    UpdEmpleado.IdMentor = capemp.IdMentor;
                    UpdEmpleado.IdProceso = capemp.IdProceso;
                    UpdEmpleado.Maquina = capemp.Maquina;
                    UpdEmpleado.Pieza = capemp.Pieza;
                    UpdEmpleado.Turno = capemp.Turno;
                    UpdEmpleado.Activo = capemp.Activo;
                    UpdEmpleado.IdNivelCertificacion = capemp.IdNivelCertificacion;



                    CapacitacionEmp.UpdateCpacitacionEmpleado(UpdEmpleado, ip);

                    respAltaFabricante.Id = IdRespNewExamenCertifica;
                    respAltaFabricante.Codigo = "200";
                    respAltaFabricante.Mensaje = "OK";
                    return respAltaFabricante;
                }
                else
                {
                    respAltaFabricante.Id = 0;
                    respAltaFabricante.Codigo = "401";
                    respAltaFabricante.Mensaje = "No se realizo el alta";
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateExamenCertificaFirmaExamen(long IdExamenCertificacion, string ip)
        {

            //var itemBuscado = findMaquinaPorId(req.IdMaquina);
            var itemBuscado = FindOnlyExamenCertificaPorId(IdExamenCertificacion);
            if (itemBuscado == null)
            {
                return false;
            }
            else
            {
                try
                {
                    var maq = new ExamenDeCertificacion
                    {
                        IdExamenCertificacion = itemBuscado.IdExamenCertificacion,
                        IdCapacitacionEmpleado = itemBuscado.IdCapacitacionEmpleado,
                        TotalFinalExamen = itemBuscado.TotalFinalExamen,
                        FechaExamen = itemBuscado.FechaExamen,
                        FechaFirmaFinal = DateTime.Now,
                        EstadoExamen = itemBuscado.EstadoExamen,
                        Concluido = true,
                        Activo = true,
                    };




                    var respNewItem = ExamenCertificaData.UpdateExamenCertificacion(maq, ip);
                    if (respNewItem > 0)
                    {
                        
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
            }
        }

        public ExamenDeCertificacion FindOnlyExamenCertificaPorId(long id)
        {
            return ExamenCertificaData.FindOnlyExamenCertificaPorId(id);
        }
    }
}
