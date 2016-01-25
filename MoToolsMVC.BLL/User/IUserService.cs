using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.User
{
    public interface IUserService : IMoToolsService
    {
        UsersRCA GetUser(string username);
    }
}
