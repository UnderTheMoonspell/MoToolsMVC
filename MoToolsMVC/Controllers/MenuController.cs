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
        private IServiceUnitOfWork _serviceUnitOfWork;

        public MenuController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }
        
        public ActionResult Get(string username)
        {
            MenuTree menuTree = Session["MenuTree"] as MenuTree;
            if (menuTree == null)
            {
                menuTree = _serviceUnitOfWork.MenuService.GetMenuByUser(username, HttpContext.Request.ApplicationPath.ToString());
                Session.Add("MenuTree", menuTree);
            }
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _serviceUnitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}