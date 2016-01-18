using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoToolsMVC.DAL.Menu;

namespace MoToolsMVC.DAL
{
    public class MenuRepository : IMenuRepository
    {
        RioJaneiroEntities _dbcontext;
        public MenuRepository(RioJaneiroEntities dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public List<Get_Menu_MVC_Result> GetMenuByUser(string username)
        {
            var menuList = _dbcontext.Get_Menu_MVC(username);
            return menuList.ToList();
        }
    }
}
