using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL
{
    public interface IGenericRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(object id);
    }
}
