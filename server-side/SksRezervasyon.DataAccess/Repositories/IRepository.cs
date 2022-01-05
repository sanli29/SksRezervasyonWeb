using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);

        TEntity GetById(int id);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);


    }
}
