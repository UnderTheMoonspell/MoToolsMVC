using MoToolsMVC.BLL.Menu;
using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.Controllers
{
    public class HomeController : Controller
    {
        private IMenuService _menuservice;

        public HomeController(IMenuService menuService)
        {
            this._menuservice = menuService;
        }
        public ActionResult Index()
        {
            //string username = "boanateladmin";
            //List<Get_Menu_MVC_Result> menuTree = Session["MenuTree"] as List<Get_Menu_MVC_Result>;
            //if (menuTree == null)
            //{
            //    menuTree = _menuservice.GetMenuByUserTest(username, HttpContext.Request.ApplicationPath.ToString());
            //    Session.Add("MenuTree", menuTree);
            //}
            //return View(menuTree);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}