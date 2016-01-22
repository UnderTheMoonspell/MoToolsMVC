using MoToolsMVC.BLL;
using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.Controllers
{
    public class UserController : Controller
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        public UserController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpGet]
        public ActionResult Edit(string username)
        {
            UsersRCA user = _serviceUnitOfWork.UserService.GetUser(username);
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            _serviceUnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}