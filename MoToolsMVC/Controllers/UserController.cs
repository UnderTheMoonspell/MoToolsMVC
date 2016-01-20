using MoToolsMVC.BLL.Menu;
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
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Edit(string username)
        {
            UsersRCA user = _userService.GetUser(username);
            return View(user);
        }
    }
}