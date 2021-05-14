using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataProcessLog
    {
        private readonly CARTAVContext _context;

        public DataProcessLog()
        {
            _context = new CARTAVContext();
        }

        public  List<ProcessLog> FindAllProcessLog()
        {
            return  _context.ProcessLogs.ToList();
        }
        public ProcessLog FindProcessLog(long idLog)
        {
            return _context.ProcessLogs.AsNoTracking().SingleOrDefault(us => us.Id == idLog);
        }

        public long AddProcessLog(ProcessLog NewProcessLog)
        {
            try
            {
                var empleadoRes = _context.ProcessLogs.Add(NewProcessLog);
                _context.SaveChanges();
                return Int32.Parse(empleadoRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateProcessLog(ProcessLog editProcessLog)
        {
            try
            {
                _context.ProcessLogs.Update(editProcessLog);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        internal List<ProcessLog> FindByfechaFin(DateTime fechaFin)
        {
            //trae todo menor a fecha fin
            return _context.ProcessLogs.Where(us => us.Fecha < fechaFin).ToList();
        }

        internal List<ProcessLog> FindByFechaIni(DateTime fechaIni)
        {
            //trae todo mayor a fecha ini
            return _context.ProcessLogs.Where(us => us.Fecha > fechaIni).ToList();
        }

        internal List<ProcessLog> FindByFechas(DateTime fechaIni, DateTime fechaFin)
        {
            //trae basado en los parametros de fechaini y fechafin
            return (List<ProcessLog>)_context.ProcessLogs.Where(us => us.Fecha >= fechaIni && us.Fecha <= fechaFin).ToList();
        }
    }
}
