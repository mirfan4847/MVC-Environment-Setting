using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using EnvironmentSetting.ExceptionManager;

namespace EnvironmentSetting.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext Context)
        {
            _Context = Context;
            this.DbSet = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
            }
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            try
            {
                _Context.Set<TEntity>().AddRange(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return
                    _Context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Get(int Id)
        {
            try
            {
                return _Context.Set<TEntity>().Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _Context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity SignleOrDefault(Expression<Func<TEntity, bool>> Predicate)
        {
            try
            {
                return _Context.Set<TEntity>().SingleOrDefault(Predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
