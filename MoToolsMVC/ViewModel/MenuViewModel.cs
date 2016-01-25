using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoToolsMVC.ViewModel
{
    public class MenuViewModel
    {
        public string MenuTree { get; set; }
        public bool? isMenuOpen { get; set; }

        public MenuViewModel(string menuTree, bool? isMenuOpen)
        {
            this.MenuTree = menuTree;
            this.isMenuOpen = isMenuOpen;
        }

        public MenuViewModel()
        {

        }
    }
}