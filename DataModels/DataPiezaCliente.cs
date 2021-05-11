using APIRestV2.Models;
using APIRestV2.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataPiezaCliente
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataPiezaCliente()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<VwPiezaCliente> FindAllPiezaCliente()
        {
           
            return _context.VwPiezaClientes.ToList();
          
        }
       


       public VwPiezaCliente findPiezaPorIdPieza(long idPieza)
        {
            return _context.VwPiezaClientes.AsNoTracking().SingleOrDefault(p => p.PiezaIdPieza == idPieza);
        }

        public long AddPiezaCliente(PiezaCliente item,string ip)
        {
            try
            {
                var PiezaRes = _context.PiezaClientes.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(PiezaRes.Entity.ClienteIdCliente.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.InnerException.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
      
    }
}
