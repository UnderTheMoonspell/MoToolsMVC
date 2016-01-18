using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Menu
{
    public class MenuTree
    {
        public List<MenuNode> nodes { get; set; }

        public MenuTree()
        {
            this.nodes = new List<MenuNode>();
        }

        public MenuTree(List<MenuNode> nodes)
        {
            this.nodes = nodes;
        }

    }
}
