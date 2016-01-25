using MoToolsMVC.DAL.CaseDDLOptions;
using MoToolsMVC.DAL.Menu;
using MoToolsMVC.DAL.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private RioJaneiroEntities _dbContext;
        private IMenuRepository _menuRepository;
        private IGenericRepository<UsersRCA> _userRepository;
        private ICaseDDLOptionsRepository _caseDDLOptionsRepository;
        private IUploadRepository _uploadRepository;

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

        public ICaseDDLOptionsRepository CaseDDLOptionsRepository
        {
            get
            {
                if (this._caseDDLOptionsRepository == null)
                {
                    this._caseDDLOptionsRepository = new CaseDDLOptionsRepository(_dbContext);
                }
                return _caseDDLOptionsRepository;
            }
        }

        public IUploadRepository UploadRepository
        {
            get
            {
                if (this._uploadRepository == null)
                {
                    this._uploadRepository = new UploadRepository(_dbContext);
                }
                return _uploadRepository;
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
