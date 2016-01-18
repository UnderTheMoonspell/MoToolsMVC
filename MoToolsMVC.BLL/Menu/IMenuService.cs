using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Menu
{
    public interface IMenuService
    {
        List<MenuObject> GetMenuByUser(string username);
    }
}
