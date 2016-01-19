using MoToolsMVC.BLL;
using MoToolsMVC.BLL.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            MenuTree menuTree = Session["MenuTree"] as MenuTree;
            if (menuTree == null)
            {
                menuTree = _menuservice.GetMenuByUser(username, HttpContext.Request.ApplicationPath.ToString());
                Session.Add("MenuTree", menuTree);
            }
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

    }

}