using APIRestV2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRestV2.Models.Response;

namespace APIRestV2.DataModels
{
    public class DataPreguntaProceso
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataPreguntaProceso()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaProceso> findAllPreguntaProceso()
        {
            return _context.PreguntaProcesos.ToList();
        }

        public PreguntaProceso findPreguntaProcesoIdPreguntaProceso(long id)
        {
            return _context.PreguntaProcesos.AsNoTracking().SingleOrDefault(us => us.IdPreguntaProceso == id);
        }

        public List<PreguntaProceso> findPreguntaProcesoIdMaquinaProceso(long id)
        {
            var preguntas = _context.PreguntaProcesos.Where(us => us.MaquinaProcesoIdMaquinaProceso == id);
            return preguntas.ToList();
        }

        public List<ResponsePreguntasTotalesProcesos> FindGlobalPreguntasIdMaquinaIdNivelCertifica(long IdProceso, string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {
            List<ResponsePreguntasTotalesProcesos> GlobalPreguntasProceso = new();
            List<PreguntaGeneral> PreguntaGralProcesos = new();
            List<PreguntaProceso> resultsPregProceso = new();
            if (IdMaquina.Contains("ALL"))
            {
                string[] TemIdMaquina = IdMaquina.Split("--");
                List<MaquinaProceso> results = _context.MaquinaProcesos
                            .FromSqlRaw("select * from MaquinaProceso where Activo = 1 and ProcesoIdProceso = " + IdProceso.ToString() + " and MaquinaIdMaquina in " + TemIdMaquina[1].ToString()).AsNoTracking()
                            .ToList();
                int UsaPregGral = 0;
                string IdMaquinaProc = "(";

                foreach (var item in results)
                {
                    IdMaquinaProc += item.IdMaquinaProceso + ",";
                    if (item.UsaPreguntaEstandar)
                    {
                        UsaPregGral += 1;
                    }
                }
                IdMaquinaProc=IdMaquinaProc.TrimEnd(',');
                IdMaquinaProc += ")";



                if (UsaPregGral > 0)
                {
                    PreguntaGralProcesos = _context.PreguntaGenerals.Where(us => us.TipoPreguntaIdTipoPregunta == 2 && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo == true).ToList();
                }

                resultsPregProceso = _context.PreguntaProcesos
                            .FromSqlRaw("select * from PreguntaProceso where Activo = 1 and IdiomaIdIdioma= " + IdIdioma + " and NivelCertificacionIdNivelCertificacion = " + IdNivelCertifica +" and MaquinaProcesoIdMaquinaProceso in " + IdMaquinaProc.ToString()).AsNoTracking()
                            .ToList();


            }
            else
            {
                MaquinaProceso results = _context.MaquinaProcesos.AsNoTracking().SingleOrDefault(mp => mp.MaquinaIdMaquina == long.Parse(IdMaquina) && mp.Activo == true && mp.ProcesoIdProceso == IdProceso);
                if (results.UsaPreguntaEstandar)
                {
                    PreguntaGralProcesos = _context.PreguntaGenerals.AsNoTracking().Where(us => us.TipoPreguntaIdTipoPregunta == 2 && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo == true).ToList();
                }

                resultsPregProceso = _context.PreguntaProcesos.AsNoTracking().Where(p => p.MaquinaProcesoIdMaquinaProceso == results.IdMaquinaProceso && p.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && p.IdiomaIdIdioma == IdIdioma && p.Activo == true).ToList();

            }
            return GlobalPreguntasProceso = CreaGlobalPreguntasMaquina(GlobalPreguntasProceso, PreguntaGralProcesos, resultsPregProceso);
        }

        public List<ResponsePreguntasTotalesProcesos> CreaGlobalPreguntasMaquina(List<ResponsePreguntasTotalesProcesos> GlobalPreguntasProceso, List<PreguntaGeneral> PreguntaGralProcesos, List<PreguntaProceso> resultsPregProceso)
        {
            //List<ResponsePreguntasTotalesMaquina> RegresaGlobalPreguntasMaquina = new();
            int init = 0;
            foreach (var item in PreguntaGralProcesos)
            {
                ResponsePreguntasTotalesProcesos Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaGeneral;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdMaquinaProceso = 0;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion = item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = true;
                GlobalPreguntasProceso.Add(Tempres);

            }

            foreach (var item in resultsPregProceso)
            {
                ResponsePreguntasTotalesProcesos Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaProceso;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdMaquinaProceso = item.MaquinaProcesoIdMaquinaProceso;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion = item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = false;
                GlobalPreguntasProceso.Add(Tempres);

            }



            return GlobalPreguntasProceso;

        }


        public long AddPreguntaProceso(PreguntaProceso item, string ip)
        {
            try
            {
                var PreguntaProcesoRes = _context.PreguntaProcesos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PreguntaProcesoRes.Entity.IdPreguntaProceso.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaProceso(PreguntaProceso item, string ip)
        {
            try
            {
                _context.PreguntaProcesos.Update(item);
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
