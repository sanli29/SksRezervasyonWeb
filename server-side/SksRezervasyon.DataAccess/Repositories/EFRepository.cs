using Microsoft.EntityFrameworkCore;
using SksRezervasyon.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.DataAccess.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SksRezervasyonDbContext context;
        private DbSet<TEntity> _dbSet;
        public EFRepository(SksRezervasyonDbContext context)
        {
            this.context = context;
            _dbSet = context.Set<TEntity>();

        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Add hata çıktı", ex);
            }

        }

        public TEntity Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                if (entity == null) return null;
                else
                {
                    TEntity _entity = entity;
                    _entity.GetType().GetProperty("Status").SetValue(_entity, 0);
                    this.Update(_entity);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete hata çıktı", ex);
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Update hata çıktı", ex);
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return _dbSet.Where(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Get hata çıktı", ex);
            }

        }


        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return _dbSet.Where(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("GetAll hata çıktı", ex);
            }

        }

        public TEntity GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("GetByID hata çıktı", ex);
            }

        }

    }
}
