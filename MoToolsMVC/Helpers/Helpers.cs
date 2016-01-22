using MoToolsMVC.BLL.Menu;
using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.Helpers
{
    public static class Helper
    {
        public static class Session
        {

            public static T GetSession<T>(string key)
            {
                return (T)HttpContext.Current.Session[key];
            }

            public static void SetSession(string key, object value)
            {
                HttpContext.Current.Session[key] = value;
            }
        }
    }
}