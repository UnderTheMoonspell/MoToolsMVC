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

        public string GetMenuByUser(string username, string rootUrl)
        {
            //SO PARA TESTE
            this._rootUrl = rootUrl;
            username = "boanateladmin";
            //
            List<Get_Menu_MVC_Result> menuObj = _unitOfWork.MenuRepository.GetMenuByUser(username);
            List<int> teamIDs = menuObj.Select(l => l.BDTEamID).Distinct().OrderBy(l => l.Value).Select(l => l.Value).ToList();
            StringBuilder finalHtml = new StringBuilder("<ul class=\"master-node\">");
            foreach (int teamId in teamIDs)
            {
                finalHtml.Append(BuildMenu(menuObj, null, teamId));
            }
            finalHtml.Append("</ul>");
            return finalHtml.ToString();
        }


        private string BuildMenu(List<Get_Menu_MVC_Result> menuList, int? parentId, int BDTeamId)
        {
            List<Get_Menu_MVC_Result> filteredMenu = menuList.FindAll(x => x.ParentID == parentId && x.BDTEamID == BDTeamId);
            StringBuilder levelHtml = new StringBuilder();
            foreach (Get_Menu_MVC_Result menu in filteredMenu)
            {
                Node node = CreateNode(menu);
                levelHtml.Append(node.ReturnNodeHTML);                   
                if(!node.IsLastChildNode) 
                {
                    levelHtml.Append(BuildMenu(menuList, menu.ID, menu.BDTEamID.Value));
                    levelHtml.Append(node.CloseNodeHtml);
                }
            }
            return levelHtml.ToString();
        }

        private Node CreateNode(Get_Menu_MVC_Result menu)
        {
            string menuUrl = menu.URL != null && menu.URL != "" ? menu.URL.Replace("~/", _rootUrl) : null;

            if (menu.ParentID == null && (menu.ID == 0 || menu.BDTEamID == 0))
            {
                return new TeamNode(menu.Name, menuUrl);
            }
            else
            {
                if (menuUrl == null)
                {
                    return new ParentNode(menu.Name, menuUrl);
                }
                else
                {
                    return new ChildNode(menu.Name, menuUrl);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                }
            }
        }
    }
}
