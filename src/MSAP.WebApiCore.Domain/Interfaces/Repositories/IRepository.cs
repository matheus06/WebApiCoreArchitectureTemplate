using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MSAP.WebApiCore.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}