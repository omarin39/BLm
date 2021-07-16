using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPuesto
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPuesto()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Puesto> FindAllPuestos()
        {

            return _context.Puestos.ToList();
        }
        public Puesto FindPuesto(int tipoBusqueda, long id_puestoExterno, string nombrePuesto)
        {
            Puesto resultadobusqueda = new();
            switch (tipoBusqueda)
            {
                case 1:
                    resultadobusqueda = _context.Puestos.SingleOrDefault(us => us.IdPuestoExterno == id_puestoExterno);
                    break;
                case 2:
                    resultadobusqueda = _context.Puestos.SingleOrDefault(us => us.DescPuesto == nombrePuesto);
                    break;
                default:
                    break;
            }
            return resultadobusqueda;
        }

        public long AddPuesto(Puesto item,string ip)
        {
            try
            {
                var puestoRes = _context.Puestos.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(puestoRes.Entity.IdPuesto.ToString());
            }
            catch (Exception ex  )
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0; ;
            }
        }

        public long UpdatePuesto()//(long id_puestoExterno, string nombrePuesto)
        {
            try
            {
                //_context.Puestos.Update(editPuesto);
                //procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0; ;
            }
        }
    }
}
