using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Interfaces.Services;

namespace MSAP.WebApiCore.Domain.Services
{
    public class Service<TEntity>: IDisposable, IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
             return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
             return  _repository.Search(predicate);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}