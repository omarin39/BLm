using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataLog
    {
        private readonly Carta_vContext _context;

        public DataLog()
        {
            _context = new Carta_vContext();
        }

        public List<ProcessLog> FindAllLogs()
        {
            return  _context.ProcessLogs.ToList();
        }
        public ProcessLog FindLog(long idLog)
        {
            return _context.ProcessLogs.AsNoTracking().SingleOrDefault(us => us.Id == idLog);
        }

        public long AddLog(ProcessLog NewLog)
        {
            try
            {
                var LogRes = _context.ProcessLogs.Add(NewLog);
                _context.SaveChanges();
                return Int32.Parse(LogRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateLog(ProcessLog _Log)
        {
            try
            {
                _context.ProcessLogs.Update(_Log);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        
    }
}
