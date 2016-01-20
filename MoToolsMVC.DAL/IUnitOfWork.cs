using MoToolsMVC.DAL.Menu;
using MoToolsMVC.DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL
{
    public interface IUnitOfWork
    {
        void Commit();
        IMenuRepository MenuRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
