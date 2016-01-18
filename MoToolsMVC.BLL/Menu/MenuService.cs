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
        IUnitOfWork _unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;           
        }

        public List<MenuObject> GetMenuByUser(string username)
        {
            List<MenuObject> menuobj = _unitOfWork._menuRepository.GetMenu();
            List<int> teamIDs = menuobj.Select(l => l.BDTeamID).Distinct().OrderBy(l => l.Value).Select(l => l.Value).ToList();
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
    }
}
