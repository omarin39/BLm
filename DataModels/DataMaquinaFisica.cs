using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMaquinaFisica
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataMaquinaFisica()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<ResponseMaquinaFisica> FindAllMaquinaFisica()
        {
            var query = from pop in _context.MaquinaFisicas
                        join ma in _context.Set<Maquina>()
                        on new { A = pop.MaquinaIdMaquina }
                        equals new { A = ma.IdMaquina }
                        join o in _context.Set<Plantum>()
                        on new { A = pop.PlantaIdPlanta }
                        equals new { A = o.IdPlanta }
                        join na in _context.Set<Nave>()
                        on new { A = pop.NaveIdNave, B = pop.PlantaIdPlanta }
                        equals new { A = na.IdNave, B = na.PlantaIdPlanta }
                        join li in _context.Set<LineaProduccion>()
                        on new { A = pop.LineaProduccionIdLineaProduccion, B = pop.NaveIdNave }
                        equals new { A = li.Id, B = li.IdNave }
                        select new ResponseMaquinaFisica { IdMaquinaFisica = pop.IdMaquinaFisica, Nserie = pop.Nserie, Ubicacion = pop.Ubicacion, MaquinaPt = pop.MaquinaPt, MaquinaIdMaquina = pop.MaquinaIdMaquina, PlantaIdPlanta = pop.PlantaIdPlanta, NaveIdNave = pop.NaveIdNave, LineaProduccionIdLineaProduccion = pop.LineaProduccionIdLineaProduccion, Activo = pop.Activo, NombreMaquina = ma.Nombre, NombrePlanta = o.Planta, NombreNave = na.Nombre, NombreLineaProduccion = li.NombreLinea };
            List<ResponseMaquinaFisica> res = query.ToList();
            return res;
        }      

        public bool ValidaNSerieExistente(string nserie)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.MaquinaFisicas.AsNoTracking().SingleOrDefault(us => us.Nserie.Trim().ToUpper() == nserie.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public MaquinaFisica findMaquinaFisicaPorIdMaquinaFisica(long id)
        {
            return _context.MaquinaFisicas.AsNoTracking().SingleOrDefault(p => p.IdMaquinaFisica == id);
        }

        public long AddMaquinaFisica(MaquinaFisica item, string ip)
        {
            try
            {
                var MaquinaFisicaRes = _context.MaquinaFisicas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(MaquinaFisicaRes.Entity.IdMaquinaFisica.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateMaquinaFisica(MaquinaFisica item, string ip)
        {
            try
            {
                _context.MaquinaFisicas.Update(item);
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
