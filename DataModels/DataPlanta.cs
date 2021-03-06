using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPlanta
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPlanta()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Plantum> FindAllPlantas()
        {
            return  _context.Planta.Include("Naves").ToList();
        }
        public Plantum FindPlanta(string idPlantaExt)
        {
            return _context.Planta.AsNoTracking().SingleOrDefault(us => us.IdPlantaExterno == idPlantaExt);
        }

        public bool FindPlantaIdexttAcro(int Tipobusqueda, RequestPlanta BusquedaVar)
        {
            Plantum busqueda = new();
            switch (Tipobusqueda)
            {
                case 1:
                    busqueda = _context.Planta.AsNoTracking().SingleOrDefault(us => us.IdPlantaExterno == BusquedaVar.IdPlantaExterno.ToString() && us.IdPlanta != BusquedaVar.IdPlanta);
                    break;
                case 2:
                    busqueda = _context.Planta.AsNoTracking().SingleOrDefault(us => us.Acronimo.Trim().ToUpper() == BusquedaVar.Acronimo.Trim().ToUpper() && us.IdPlanta != BusquedaVar.IdPlanta);
                    break;
                default:
                    break;
            }
            return busqueda == null ? false : true;
        }

        public bool ValidaClaveExistente(string acronimo)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.Planta.AsNoTracking().SingleOrDefault(us => us.Acronimo.Trim().ToUpper() == acronimo.Trim().ToUpper());
            return busqueda == null ? false : true;
        }

        public bool ValidaClaveExistente2(long idExterno)
        {
            //true si existe
            //false si no existe
            var busqueda = _context.Planta.AsNoTracking().SingleOrDefault(us => us.IdPlantaExterno == idExterno.ToString());
            return busqueda == null ? false : true;
        }

        public long AddPlanta(Plantum item,string ip)
        {
            try
            {
                var plantaRes = _context.Planta.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(plantaRes.Entity.IdPlanta.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePlanta(Plantum item,string ip)
        {
            try
            {
                _context.Planta.Update(item);
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
