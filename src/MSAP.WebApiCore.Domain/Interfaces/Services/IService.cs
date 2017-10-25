using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MSAP.WebApiCore.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

    }
}