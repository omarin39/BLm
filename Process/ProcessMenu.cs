using APIRestV2.DataModels;
using APIRestV2.Models;
using APIRestV2.Models.Request;
using APIRestV2.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRestV2.Process
{
    public class ProcessMenu
    {
        public DataMenu MenuData = new();
        public ResponseGral AddMenu(RequestMenu _menu, String ip)
        {
            ResponseGral respAltaMenu = new();
            try
            {
                Menu logNewRegistro = new();
                logNewRegistro.NombreMenu= _menu.NombreMenu;
                logNewRegistro.Operacions= _menu.Operaciones;
                logNewRegistro.Activo = _menu.Activo;
                long respNewUSR = MenuData.AddMenu(logNewRegistro,ip);
                if (respNewUSR > 0)
                {
                    respAltaMenu.Id = respNewUSR;
                    respAltaMenu.Codigo = "200";
                    return respAltaMenu;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ResponseGral UpdateMenu(RequestMenu _menu, String ip)
        {
            ResponseGral respUpdateMenu = new();
            var MenuBuscado = FindMenu(_menu.Id);
            if (MenuBuscado == null)
            {
                return respUpdateMenu;
            }
            else
            {
                try
                {
                    MenuBuscado.NombreMenu = _menu.NombreMenu;
                    MenuBuscado.Operacions = _menu.Operaciones;
                    MenuBuscado.Activo = _menu.Activo;
                    var respNewMenu = MenuData.UpdateMenu(MenuBuscado,ip);
                    if (respNewMenu > 0)
                    {
                        respUpdateMenu.Id = MenuBuscado.Id;
                        respUpdateMenu.Codigo = "200";
                        return respUpdateMenu;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public Menu FindMenu(long idMenu)
        {
            Menu resMenu = MenuData.FindMenu(idMenu);
            if (resMenu == null)
            {
                resMenu.Id = -1;
            }
            return resMenu;
        }
        public List<Menu> FindAllMenu()
        {
            List<Menu> resManuRet = MenuData.FindAllMenu();
            return resManuRet;
        }
    }
}
