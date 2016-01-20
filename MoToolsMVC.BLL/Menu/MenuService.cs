using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Menu
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private string _rootUrl { get; set; }
        public MenuService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;           
        }

        public MenuTree GetMenuByUser(string username, string rootUrl)
        {
            //SO PARA TESTE
            this._rootUrl = rootUrl;
            username = "boanateladmin";
            MenuTree menuTree = new MenuTree();
            MenuNode newMenuNode = new MenuNode();

            List<Get_Menu_MVC_Result> menuObj = _unitOfWork.MenuRepository.GetMenuByUser(username);
            List<int> teamIDs = menuObj.Select(l => l.BDTEamID).Distinct().OrderBy(l => l.Value).Select(l => l.Value).ToList();

            foreach(int teamId in teamIDs)
            {
                BuildMenu(menuTree, menuObj, null, newMenuNode, teamId);
            }
            return menuTree;
        }

        private void BuildMenu(MenuTree menuTree, List<Get_Menu_MVC_Result> menuList, int? parentId, MenuNode inProgressNode, int BDTeamId)
        {

            List<Get_Menu_MVC_Result> filteredMenu = menuList.FindAll(x => x.ParentID == parentId && x.BDTEamID == BDTeamId);

            //string prevBdTeamId, bdTeamId, menuID, newParentId, label, targetLink, newId;

            foreach (Get_Menu_MVC_Result menu in filteredMenu)
            {
                string menuUrl = menu.URL != null ? menu.URL.Replace("~/",this._rootUrl) : null;
                MenuNode node = new MenuNode((menu.ID + "-" + menu.BDTEamID).ToString(), menu.Name, menuUrl);

                if (menu.ParentID == null && (menu.ID == 0 || menu.BDTEamID == 0))
                {
                    menuTree.nodes.Add(node);
                }
                else
                {
                    inProgressNode.children.Add(node);
                }
                BuildMenu(menuTree, menuList, menu.ID, node, menu.BDTEamID.Value);
            }
        }
    }
}
