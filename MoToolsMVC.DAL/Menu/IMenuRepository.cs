using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoToolsMVC.DAL.Menu
{
    public interface IMenuRepository<T> where T : class
    {
        List<MenuObject> GetMenuByUser(string username);
    }
}
