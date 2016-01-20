using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoToolsMVC.DAL.User
{
    public interface IUserRepository : IGenericRepository<UsersRCA>
    {
        UsersRCA GetUser(string username);
    }
}
