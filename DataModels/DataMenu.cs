using APIRestV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.DataModels
{
    public class DataMenu
    {
        private readonly CARTAVContext _context;
        private Controllers.Process.Process_Log procLog;
        public DataMenu()
        {
            _context = new CARTAVContext();
            procLog = new Controllers.Process.Process_Log();
        }

        public List<Menu> FindAllMenu()
        {
            List<Menu> MenuGral = _context.Menus.Include("Operacions").ToList();
            return MenuGral;
        }
        public Menu FindMenu(long idMenu)
        {
            return _context.Menus.AsNoTracking().SingleOrDefault(us => us.Id == idMenu);

        }

        public long AddMenu(Menu item,string ip)
        {
            try
            {
                var menuRes = _context.Menus.Add(item);
                _context.SaveChanges();
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), "OK", 200);
                return Int32.Parse(menuRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {
                procLog.AddLog(ip, procLog.GetPropertyValues(item, System.Reflection.MethodBase.GetCurrentMethod().Name), ex.Message, 400);
                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateMenu(Menu item,string ip)
        {
            try
            {
                _context.Menus.Update(item);
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
