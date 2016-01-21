using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoToolsMVC.DAL.User;
using System.Data.Entity;

namespace MoToolsMVC.DAL.User
{
    public class UserRepository : GenericRepository<UsersRCA>
    {
        public UserRepository(RioJaneiroEntities dbcontext) : base(dbcontext)
        {

        }
    }
}
