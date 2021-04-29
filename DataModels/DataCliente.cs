﻿using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataCliente
    {
        private readonly Carta_vContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataCliente()
        {
            _context = new Carta_vContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public  List<Cliente> FindAllCliente()
        {
            return  _context.Clientes.ToList();
        }
        public Cliente FindCliente(long idCliente)
        {
            return _context.Clientes.AsNoTracking().SingleOrDefault(us => us.IdCliente == idCliente);
        }

        public long AddCliente(Cliente item,string ip)
        {
            try
            {
                var ClienteRes = _context.Clientes.Add(item);
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                _context.SaveChanges();
                return Int32.Parse(ClienteRes.Entity.IdCliente.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateCliente(Cliente item,string ip)
        {
            try
            {
                _context.Clientes.Update(item);
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
