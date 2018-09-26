using System;
using System.Linq;

namespace DockerSample.Domain.Contract.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
