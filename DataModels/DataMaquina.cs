using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMaquina
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataMaquina()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<VwMaquinaPregunta> FindAllMaquina()
        {
            return _context.VwMaquinaPreguntas.ToList();
        }

        public bool ValidaClaveExistente(string nombre)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.VwMaquinaPreguntas.AsNoTracking().SingleOrDefault(us => us.Nombre.Trim().ToUpper() == nombre.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public VwMaquinaPregunta findPiezaPorIdPieza(long id)
        {
            return _context.VwMaquinaPreguntas.AsNoTracking().SingleOrDefault(p => p.IdMaquina == id);
        }

        public Maquina FindMaquina(long id)
        {
            return _context.Maquinas.AsNoTracking().SingleOrDefault(p => p.IdMaquina == id);
        }

        public List<Maquina> FindMaquinasByPlanta(long planta)
        {
            var query = from m in _context.Maquinas 
                        join mf in _context.MaquinaFisicas on m.IdMaquina equals mf.MaquinaIdMaquina
                        join p in _context.Planta.Where(us => us.IdPlanta == planta) on mf.PlantaIdPlanta equals p.IdPlanta 
                        select m;

            return query.ToList();
        }

        public List<Maquina> FindMaquinasByPlantaNave(long planta, long nave)
        {
            var query = from m in _context.Maquinas
                        join mf in _context.MaquinaFisicas on m.IdMaquina equals mf.MaquinaIdMaquina
                        join p in _context.Planta.Where(us => us.IdPlanta == planta) on mf.PlantaIdPlanta equals p.IdPlanta
                        join n in _context.Naves.Where(us => us.IdNave == nave) on mf.NaveIdNave equals n.IdNave
                        select m;

            return query.ToList();
        }

        public long AddMaquina(Maquina item,string ip)
        {
            try
            {
                var PiezaRes = _context.Maquinas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdMaquina.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateMaquina(Maquina item, string ip)
        {
            try
            {
                _context.Maquinas.Update(item);
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
