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
        private IServiceUnitOfWork _serviceUnitOfWork;

        public MenuController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }

        public ActionResult Get(string username)
        {
            string menuTree = Helper.Session.GetSession<string>("MenuTree");
            if (menuTree == null)
            {
                menuTree = _serviceUnitOfWork.MenuService.GetMenuByUser(username, HttpContext.Request.ApplicationPath.ToString());
                Session.Add("MenuTree", menuTree);
                Helper.Session.SetSession("MenuTree", menuTree);
            }
            return PartialView("_Menu", menuTree);
        }

        protected override void Dispose(bool disposing)
        {
            _serviceUnitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}