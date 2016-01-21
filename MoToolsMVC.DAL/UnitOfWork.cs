﻿using MoToolsMVC.DAL.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private RioJaneiroEntities _dbContext;
        private IMenuRepository _menuRepository;
        private IGenericRepository<UsersRCA> _userRepository;

        public UnitOfWork()
        {
            _dbContext = new RioJaneiroEntities();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #region Repositories
        public IMenuRepository MenuRepository
        {
            get
            {
                if (this._menuRepository == null)
                {
                    this._menuRepository = new MenuRepository(_dbContext);
                }
                return _menuRepository;
            }
        }

        public IGenericRepository<UsersRCA> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<UsersRCA>(_dbContext);
                }
                return _userRepository;
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
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
