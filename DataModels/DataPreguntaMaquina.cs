using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPreguntaMaquina
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPreguntaMaquina()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<PreguntaMaquina> FindAllPreguntaMaquina()
        {
           
            return _context.PreguntaMaquinas.ToList();
          
        }
       


       public PreguntaMaquina findPreguntaMaquinaIdMaquina(long id)
        {
            return _context.PreguntaMaquinas.AsNoTracking().SingleOrDefault(p => p.IdPreguntaMaquina == id);
        }

        public List<PreguntaMaquina> FindPreguntaPorIdMaquina(long _IdMaquina)
        {
            return _context.PreguntaMaquinas.AsNoTracking().Where(p => p.MaquinaIdMaquina == _IdMaquina).ToList(); ;
        }

        public List<ResponsePreguntasTotalesMaquina> FindGlobalPreguntasIdMaquinaIdNivelCertifica(string IdMaquina, long IdNivelCertifica, long IdIdioma)
        {
            List<ResponsePreguntasTotalesMaquina> GlobalPreguntasMaquina = new();
            List<PreguntaGeneral> PreguntaGralMaquina = new();
            List<PreguntaMaquina> resultsPregMaquinas = new();

            if (IdMaquina.Contains("ALL"))
            {
                string[] TemIdMaquina = IdMaquina.Split("--");
                List<Maquina> results = _context.Maquinas
                            .FromSqlRaw("select * from Maquina where activo =1 and IdMaquina in " + TemIdMaquina[1].ToString()).AsNoTracking()
                            .ToList();
                int UsaPregGral = 0;

                foreach (var item in results)
                {
                    if (item.UsaPreguntaEstandar)
                    {
                        UsaPregGral += 1;
                    }
                }

                
                if (UsaPregGral>0)
                {
                    PreguntaGralMaquina = _context.PreguntaGenerals.AsNoTracking().Where(us => us.TipoPreguntaIdTipoPregunta == 1 && us.NivelCertificacionIdNivelCertificacion== IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo==true).ToList();
                }

                resultsPregMaquinas = _context.PreguntaMaquinas
                            .FromSqlRaw("select * from PreguntaMaquina where  NivelCertificacionIdNivelCertificacion=1 and IdiomaIdIdioma=1 and activo= 1 and MaquinaIdMaquina in " + TemIdMaquina[1].ToString()).AsNoTracking()
                            .ToList();
                

            }
            else
            {
                Maquina results = _context.Maquinas.AsNoTracking().SingleOrDefault(ma => ma.IdMaquina == long.Parse(IdMaquina) && ma.Activo == true);
                if (results.UsaPreguntaEstandar)
                {
                    PreguntaGralMaquina = _context.PreguntaGenerals.AsNoTracking().Where(us => us.TipoPreguntaIdTipoPregunta == 1 && us.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && us.IdiomaIdIdioma == IdIdioma && us.Activo == true).ToList();
                }

                resultsPregMaquinas = _context.PreguntaMaquinas.AsNoTracking().Where(p => p.MaquinaIdMaquina == long.Parse(IdMaquina) && p.NivelCertificacionIdNivelCertificacion == IdNivelCertifica && p.IdiomaIdIdioma == IdIdioma && p.Activo == true).ToList();

            }

            return GlobalPreguntasMaquina = CreaGlobalPreguntasMaquina(GlobalPreguntasMaquina, PreguntaGralMaquina, resultsPregMaquinas);

        }

        public List<ResponsePreguntasTotalesMaquina> CreaGlobalPreguntasMaquina(List<ResponsePreguntasTotalesMaquina> GlobalPreguntasMaquina, List<PreguntaGeneral> PreguntaGralMaquina, List<PreguntaMaquina> resultsPregMaquinas)
        {
            //List<ResponsePreguntasTotalesMaquina> RegresaGlobalPreguntasMaquina = new();
            int init = 0;
            foreach (var item in PreguntaGralMaquina)
            {
                ResponsePreguntasTotalesMaquina Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaGeneral;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdMaquina = 0;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion= item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = true;
                GlobalPreguntasMaquina.Add(Tempres);

            }

            foreach (var item in resultsPregMaquinas)
            {
                ResponsePreguntasTotalesMaquina Tempres = new();
                Tempres.IdGlobal = init + 1;
                Tempres.IdPregunta = item.IdPreguntaMaquina;
                Tempres.Pregunta = item.Pregunta;
                Tempres.Respuesta = item.Respuesta;
                Tempres.Orden = item.Orden;
                Tempres.IdMaquina = item.MaquinaIdMaquina;
                Tempres.IdIdioma = item.IdiomaIdIdioma;
                Tempres.IdNivelCertificacion = item.NivelCertificacionIdNivelCertificacion;
                Tempres.IsGral = false;
                GlobalPreguntasMaquina.Add(Tempres);

            }



            return GlobalPreguntasMaquina;

        }

        public long AddPreguntaMaquina(PreguntaMaquina item,string ip)
        {
            try
            {
                var PiezaRes = _context.PreguntaMaquinas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdPreguntaMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdatePreguntaMaquina(PreguntaMaquina item, string ip)
        {
            try
            {
                _context.PreguntaMaquinas.Update(item);
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
