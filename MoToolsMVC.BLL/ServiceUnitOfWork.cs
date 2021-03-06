﻿using MoToolsMVC.BLL.CaseDDLOptions;
using MoToolsMVC.BLL.Menu;
using MoToolsMVC.BLL.Attachments;
using MoToolsMVC.BLL.User;
using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL
{
    public class ServiceUnitOfWork: IServiceUnitOfWork
    {
        private IUnitOfWork _unitOfWork;
        private IMenuService _menuService;
        private IUserService _userService;
        private ICaseDDLOptionsService _caseDDLOptionsService;
        private IAttachmentsService _attachmentsService;

        public ServiceUnitOfWork(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region Services

        public IUserService UserService
        {
            get
            {
                if (this._userService == null)
                {
                    this._userService = new UserService(_unitOfWork);
                }
                return _userService;
            }
        }

        public IMenuService MenuService
        {
            get
            {
                if (this._menuService == null)
                {
                    this._menuService = new MenuService(_unitOfWork);
                }
                return _menuService;
            }
        }

        public ICaseDDLOptionsService CaseDDLOptionsService
        {
            get
            {
                if (this._caseDDLOptionsService == null)
                {
                    this._caseDDLOptionsService = new CaseDDLOptionsService(_unitOfWork);
                }
                return _caseDDLOptionsService;
            }
        }

        public IAttachmentsService AttachmentsService
        {
            get
            {
                if (this._attachmentsService == null)
                {
                    this._attachmentsService = new AttachmentsService(_unitOfWork);
                }
                return _attachmentsService;
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                }
            }
        }

        #endregion
    }
}
