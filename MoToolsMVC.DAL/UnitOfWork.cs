using MoToolsMVC.DAL.Menu;
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

        public UnitOfWork()
        {
            _dbContext = new RioJaneiroEntities();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

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
