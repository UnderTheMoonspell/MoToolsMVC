using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoToolsMVC.Session
{
    public static class SessionNames
    {
        private static readonly string _menuTree = "MenuTree";
        private static readonly string _isMenuOpen = "IsMenuCollapsed";

        public static string MenuTree { get { return _menuTree; } }
        public static string isMenuOpen { get { return _isMenuOpen; } }
    }
}