using MoToolsMVC.DAL.Menu;
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
    }
}
