using MoToolsMVC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.Controllers
{
    public class MenuController : Controller
    {
        private IMenuService _menuservice;

        public MenuController(IMenuService menuService)
        {

        }
        
        public ActionResult Get(string username)
        {
            //List<int> teamIDs2 = menuobj.Select(l => l.BDTeamID).Distinct().OrderBy(l => l.Value).Select(l => l.Value).ToList();
            MenuTree menuTree = new MenuTree();
            MenuNode newNode = new MenuNode();
            foreach (int teamId in teamIDs2)
            {
                BuildMenu(menuTree, menuobj, null, newNode, teamId);
            }
            //var jsonString = "[{\"label\": \"node1\",children: [{ \"label\": \"child1\" },{ \"label\": \"child2\" }]},{\"label\": \"node2\",children: [{ \"label\": \"child3\", children: [{ \"label\": \"child3.1\" }] }]}]";
            //List<TesteJson> test = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TesteJson>>(jsonString);
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

        private void BuildMenu(MenuTree menuTree, List<MenuObject> menuObj, int? parentId, MenuNode inProgressNode, int BDTeamId)
        {

            List<MenuObject> filteredMenu = menuObj.FindAll(x => x.ParentID == parentId && x.BDTeamID == BDTeamId);

            //string prevBdTeamId, bdTeamId, menuID, newParentId, label, targetLink, newId;

            foreach (MenuObject menu in filteredMenu)
            {
                MenuNode node = new MenuNode((menu.ID + menu.BDTeamID).ToString(), menu.Name, menu.URL);

                if (menu.ParentID == null && (menu.ID == 0 || menu.BDTeamID == 0))
                {
                    menuTree.nodes.Add(node);
                }
                else
                {
                    inProgressNode.children.Add(node);
                }
                BuildMenu(menuTree, menuObj, menu.ID, node, menu.BDTeamID.Value);
            }
        }

        private MenuNode getParentNode(List<MenuNode> checkedNodes, string parentId)
        {
            foreach (MenuNode node in checkedNodes)
            {
                if(node.id == parentId)
                {
                    return node;
                }
            }
            return null;
            //VERSAO ANTIGA
            //foreach(MenuNode node in menuTree.nodes)
            //{
            //    if(node.id == parentId)
            //    {
            //        return node;
            //    }
            //    else
            //    {
            //        foreach(MenuTree childTree in node.children)
            //        { 
            //            return getParentNode(childTree, parentId);
            //        }
            //    }
            //}
            //return null;
        }
    }

    public class MenuTree
    {
        public List<MenuNode> nodes { get; set; }

        public MenuTree()
        {

        }

        public MenuTree(List<MenuNode> nodes)
        {
            this.nodes = nodes;
        }

    }

    public class MenuNode
    {
        public string id { get; set; }
        public string label { get; set; }
        public string targetLink { get; set; }
        public List<MenuNode> children { get; set; }

        public MenuNode()
        {

        }

        public MenuNode(string id, string label, string targetLink)
        {
            this.id = id;
            this.label = label;
            this.targetLink = targetLink;
        }

        public MenuNode(string id, string label, string targetLink, List<MenuNode> children)
        {
            this.id = id;
            this.label = label;
            this.targetLink = targetLink;
            this.children = children;
        }
    }

}