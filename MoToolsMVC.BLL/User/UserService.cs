using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Menu
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;           
        }

        public UsersRCA GetUser(string username)
        {
            UsersRCA user = _unitOfWork.UserRepository.GetById(username);
            return user;
        }
    }
}
