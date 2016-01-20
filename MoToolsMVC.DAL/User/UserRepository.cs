using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoToolsMVC.DAL.User;
using System.Data.Entity;

namespace MoToolsMVC.DAL.User
{
    public class UserRepository : GenericRepository<UsersRCA>, IUserRepository
    {
        public UserRepository(RioJaneiroEntities dbcontext) : base(dbcontext)
        {

        }

        public UsersRCA GetUser(string username)
        {
            var user = _dbSet.Where(x => x.UsernameRCA == username).First();
            return user;
        }

        //public override UsersRCA GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
