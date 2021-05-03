using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataLog
    {
        private readonly CARTAVContext _context;

        public DataLog()
        {
            _context = new CARTAVContext();
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
