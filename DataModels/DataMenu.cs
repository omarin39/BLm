using APIRest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.DataModels
{
    public class DataMenu
    {
        private readonly Carta_vContext _context;

        public DataMenu()
        {
            _context = new Carta_vContext();
        }

        public List<Menu> FindAllMenu()
        {
            List<Menu> MenuGral = _context.Menus.Include("Operaciones").ToList();
            return MenuGral;
        }
        public Menu FindMenu(long idMenu)
        {
            return _context.Menus.AsNoTracking().SingleOrDefault(us => us.Id == idMenu);

        }

        public long AddMenu(Menu NewMenu)
        {
            try
            {
                var menuRes = _context.Menus.Add(NewMenu);
                _context.SaveChanges();
                return Int32.Parse(menuRes.Entity.Id.ToString());
            }
            catch (Exception ex)
            {

                var r = ex.Message;
                return 0;
            }
        }
        public int UpdateMenu(Menu editMenu)
        {
            try
            {
                _context.Menus.Update(editMenu);
                return _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
