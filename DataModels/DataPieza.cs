using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPieza
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPieza()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Pieza> FindAllPiezas()
        {
            return  _context.Piezas.ToList();
        }
        public Pieza FindPieza(string Pieza)
        {
            return _context.Piezas.AsNoTracking().SingleOrDefault(us => us.Nombre == Pieza);
        }

        public long AddPieza(Pieza item,string ip)
        {
            try
            {
                var PiezaRes = _context.Piezas.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.IdPieza.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdatePieza(Pieza item,string ip)
        {
            try
            {
                _context.Piezas.Update(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                return 0;
            }

        }
    }
}
