using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataProcessLog
    {
        private readonly Carta_vContext _context;

        public DataProcessLog()
        {
            _context = new Carta_vContext();
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
    }
}
