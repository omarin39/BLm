using APIRestV2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRestV2.Models.Response;

namespace APIRestV2.DataModels
{
    public class DataPreguntaPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataPreguntaPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaPieza> findAllPreguntaPieza()
        {
            return _context.PreguntaPiezas.ToList();
        }

        public PreguntaPieza findPreguntaPiezaIdPreguntaPieza(long id)
        {
            return _context.PreguntaPiezas.AsNoTracking().SingleOrDefault(us => us.IdPreguntaPieza == id);
        }

        public List<PreguntaPieza> findPreguntaPiezaIdProcesoPiezaMaquina(long id)
        {
            var preguntas = _context.PreguntaPiezas.Where(us => us.ProcesoPiezaMaquinaIdProcesoPiezaMaquina == id);
            return preguntas.ToList();
        }

        public List<ResponsePreguntasTotalesPiezas> FindGlobalPiezaProcesoMaquinaIdNivelCertifica(string IdPieza, long IdProceso, string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {

            List<ResponsePreguntasTotalesPiezas> GlobalPreguntasProceso = new();
            List<PreguntaGeneral> PreguntaGralPieza = new();
            List<PreguntaPieza> resultsPregPieza = new();

            if (IdPieza.Contains("ALL"))
            {
                string[] TemIdPieza = IdPieza.Split("--");
                List<ProcesoPiezaMaquina> results = _context.ProcesoPiezaMaquinas
                            .FromSqlRaw("select * from ProcesoPiezaMaquina where Activo=1 and PiezaIdPieza in " + TemIdPieza[1].ToString()).AsNoTracking()
                            .ToList();

                int UsaPregGral = 0;
                string IdMaquinaPieza = "(";
                foreach (var item in results)
                {
                    IdMaquinaPieza += item.IdProcesoPiezaMaquina + ",";
                    if (item.UsaPreguntaEstandar)
                    {
                        UsaPregGral += 1;
                    }
                }
                IdMaquinaPieza = IdMaquinaPieza.TrimEnd(',');
                IdMaquinaPieza += ")";

                if (UsaPregGral > 0)
                {
                    PreguntaGralPieza = _context.PreguntaGenerals.AsNoTracking().Where(us => us.TipoPreguntaIdTipoPregunta == 3 && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo == true).ToList();
                }

                resultsPregPieza = _context.PreguntaPiezas
                           .FromSqlRaw("select * from PreguntaPieza where Activo =1 and IdiomaIdIdioma = " + IdIdioma + " and NivelCertificacionIdNivelCertificacion=" + IdNivelCertifica + " and ProcesoPiezaMaquinaIdProcesoPiezaMaquina in" + IdMaquinaPieza).AsNoTracking()
                           .ToList();
            }
            else
            {
                string[] TemIdPieza;
                List<ProcesoPiezaMaquina> results = new();
                if (IdMaquina.Contains("ALL"))
                {
                    TemIdPieza = IdMaquina.Split("--");
                    results = _context.ProcesoPiezaMaquinas
                            .FromSqlRaw("select PPM.IdProcesoPiezaMaquina, PPM.PiezaIdPieza, PPM.MaquinaProcesoIdMaquinaProceso, PPM.UsaPreguntaEstandar, PPM.Activo from ProcesoPiezaMaquina as PPM inner join MaquinaProceso as MP on MP.IdMaquinaProceso = PPM.MaquinaProcesoIdMaquinaProceso where PPM.Activo = 1 and MP.MaquinaIdMaquina in " + TemIdPieza[1].ToString() + " and MP.ProcesoIdProceso = " + IdProceso + " and PPM.PiezaIdPieza = " + IdPieza).AsNoTracking()
                            .ToList();
                }
                else
                {
                    results = _context.ProcesoPiezaMaquinas
                            .FromSqlRaw("select PPM.IdProcesoPiezaMaquina, PPM.PiezaIdPieza, PPM.MaquinaProcesoIdMaquinaProceso, PPM.UsaPreguntaEstandar, PPM.Activo from ProcesoPiezaMaquina as PPM inner join MaquinaProceso as MP on MP.IdMaquinaProceso = PPM.MaquinaProcesoIdMaquinaProceso where PPM.Activo = 1 and MP.MaquinaIdMaquina in (" + IdMaquina + ") and MP.ProcesoIdProceso = " + IdProceso + " and PPM.PiezaIdPieza = " + IdPieza).AsNoTracking()
                            .ToList();
                }
                
                int UsaPregGral = 0;
                string IdMaquinaPieza = "";

                foreach (var item in results)
                {
                    IdMaquinaPieza += item.IdProcesoPiezaMaquina;
                    if (item.UsaPreguntaEstandar)
                    {
                        UsaPregGral += 1;
                    }
                }
                IdMaquinaPieza = IdMaquinaPieza.TrimEnd(',');


                if (UsaPregGral > 0)
                {
                    PreguntaGralPieza = _context.PreguntaGenerals.AsNoTracking().Where(us => us.TipoPreguntaIdTipoPregunta == 3 && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo == true).ToList();
                }
                resultsPregPieza = _context.PreguntaPiezas.AsNoTracking().Where(us => us.Activo == true && us.IdiomaIdIdioma == IdIdioma && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.ProcesoPiezaMaquinaIdProcesoPiezaMaquina == long.Parse(IdMaquinaPieza)).ToList();
            }
            
            return GlobalPreguntasProceso = CreaGlobalPreguntasMaquina(GlobalPreguntasProceso, PreguntaGralPieza, resultsPregPieza);
        }

        public List<ResponsePreguntasTotalesPiezas> CreaGlobalPreguntasMaquina(List<ResponsePreguntasTotalesPiezas> GlobalPreguntasProceso, List<PreguntaGeneral> PreguntaGralProcesos, List<PreguntaPieza> resultsPregProceso)
        {
            //List<ResponsePreguntasTotalesMaquina> RegresaGlobalPreguntasMaquina = new();
            int init = 0;
            foreach (var item in PreguntaGralProcesos)
            {
                ResponsePreguntasTotalesPiezas Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaGeneral;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdProcesoPiezaMaquina = 0;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion = item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = true;
                GlobalPreguntasProceso.Add(Tempres);

            }

            foreach (var item in resultsPregProceso)
            {
                ResponsePreguntasTotalesPiezas Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaPieza;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdProcesoPiezaMaquina = item.ProcesoPiezaMaquinaIdProcesoPiezaMaquina;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion = item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = false;
                GlobalPreguntasProceso.Add(Tempres);

            }



            return GlobalPreguntasProceso;

        }




        public long AddPreguntaPieza(PreguntaPieza item, string ip)
        {
            try
            {
                var PreguntaPiezaRes = _context.PreguntaPiezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaPiezaRes.Entity.IdPreguntaPieza.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaPieza(PreguntaPieza item, string ip)
        {
            try
            {
                _context.PreguntaPiezas.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                return 0;
            }

        }
    }
}
