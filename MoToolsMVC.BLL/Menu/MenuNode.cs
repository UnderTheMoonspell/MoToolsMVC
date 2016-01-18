using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Menu
{
    public class MenuNode
    {
        public string id { get; set; }
        public string label { get; set; }
        public string targetLink { get; set; }
        public List<MenuNode> children { get; set; }

        public MenuNode()
        {
            this.children = new List<MenuNode>();
        }

        public MenuNode(string id, string label, string targetLink)
        {
            this.id = id;
            this.label = label;
            this.targetLink = targetLink;
            this.children = new List<MenuNode>();
        }

        public MenuNode(string id, string label, string targetLink, List<MenuNode> children)
        {
            this.id = id;
            this.label = label;
            this.targetLink = targetLink;
            this.children = children;
            this.children = new List<MenuNode>();
        }
    }
}
