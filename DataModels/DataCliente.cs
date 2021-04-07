using APIRest.Models;
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

        public DataCliente()
        {
            _context = new Carta_vContext();
        }

        public  List<Cliente> FindAllCliente()
        {
            return  _context.Clientes.ToList();
        }
        public Cliente FindCliente(long idCliente)
        {
            return _context.Clientes.AsNoTracking().SingleOrDefault(us => us.IdCliente == idCliente);
        }

        public long AddCliente(Cliente NewCliente)
        {
            try
            {
                var ClienteRes = _context.Clientes.Add(NewCliente);
                _context.SaveChanges();
                return Int32.Parse(ClienteRes.Entity.IdCliente.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }

        public int UpdateCliente(Cliente editCliente)
        {
            try
            {
                _context.Clientes.Update(editCliente);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
