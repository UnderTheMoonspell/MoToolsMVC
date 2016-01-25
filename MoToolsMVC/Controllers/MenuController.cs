using MoToolsMVC.BLL;
using MoToolsMVC.BLL.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoToolsMVC.Helpers;
using MoToolsMVC.Session;
using MoToolsMVC.ViewModel;

namespace MoToolsMVC.Controllers
{
    public class MenuController : Controller
    {
        private IServiceUnitOfWork _serviceUnitOfWork;

        public MenuController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public ActionResult Get(string username)
        {
            string menuTree = Helper.Session.GetSession<string>(SessionNames.MenuTree);
            bool? isMenuOpen = Helper.Session.GetSession<bool?>(SessionNames.isMenuOpen);
            MenuViewModel menuVM = new MenuViewModel(menuTree, isMenuOpen);
            if (menuTree == null)
            {
                menuTree = _serviceUnitOfWork.MenuService.GetMenuByUser(username, HttpContext.Request.ApplicationPath.ToString());
                Helper.Session.SetSession(SessionNames.MenuTree, menuTree);                
                menuVM.MenuTree = menuTree;
                menuVM.isMenuOpen = isMenuOpen == true ? isMenuOpen : false;
            }
            return PartialView("_Menu", menuVM);
        }

        [HttpPost]
        public void SetMenuCookie(bool isMenuOpen)
        {
            //bool isMenuCollapsed = Helper.Session.GetSession<bool>(SessionNames.IsMenuCollapsed);
            Helper.Session.SetSession(SessionNames.isMenuOpen, isMenuOpen);
        }

        protected override void Dispose(bool disposing)
        {
            _serviceUnitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}