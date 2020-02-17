using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace EnvironmentSetting.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SignleOrDefault(Expression<Func<TEntity, bool>> Predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);
    }
}
