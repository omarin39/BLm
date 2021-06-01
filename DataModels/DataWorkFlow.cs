using APIRestV2.Models;
using APIRestV2.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataWorkFlow
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;

        public DataWorkFlow()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public Workflow findWorflowIdWorkflow(long id)
        {
            return _context.Workflows.AsNoTracking().SingleOrDefault(us => us.IdWorkFlow == id);
        }
        public List<Workflow> FindWorkflowPieza(long Pieza)
        {
            
            var wf = _context.Workflows.Where(us => us.PiezaIdPieza == Pieza).OrderBy(us => us.Orden);            
            return wf.ToList();
        }

        public long AddWorkflow(Workflow item, string ip)
        {
            try
            {
                var WorkflowRes = _context.Workflows.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(WorkflowRes.Entity.IdWorkFlow.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateWorkflow(Workflow item, string ip)
        {
            try
            {
                _context.Workflows.Update(item);
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
