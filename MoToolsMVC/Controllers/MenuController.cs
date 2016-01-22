using MoToolsMVC.BLL;
using MoToolsMVC.BLL.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoToolsMVC.Helpers;

namespace MoToolsMVC.Controllers
{
    public class MenuController : Controller
    {
        private IMenuService _menuservice;

        public MenuController(IMenuService menuService)
        {
            this._menuservice = menuService;
        }

        public ActionResult Get(string username)
        {
            string menuTree = Helper.Session.GetSession<string>("MenuTree");
            if (menuTree == null)
            {
                menuTree = _menuservice.GetMenuByUser(username, HttpContext.Request.ApplicationPath.ToString());
                Session.Add("MenuTree", menuTree);
                Helper.Session.SetSession("MenuTree", menuTree);
            }
            return PartialView("_Menu", menuTree);
        }

        protected override void Dispose(bool disposing)
        {
            _menuservice.Dispose();
            base.Dispose(disposing);
        }

    }

}