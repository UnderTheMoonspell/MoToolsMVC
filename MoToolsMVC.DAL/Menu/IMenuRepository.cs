using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoToolsMVC.DAL.Menu
{
    public interface IMenuRepository
    {
        List<Get_Menu_MVC_Result> GetMenuByUser(string username);
    }
}
