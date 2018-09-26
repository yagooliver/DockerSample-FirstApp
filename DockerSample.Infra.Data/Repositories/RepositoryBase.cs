using System;
using System.Linq;
using DockerSample.Domain.Contract.Repositories;
using DockerSample.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DockerSample.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DockerSampleContext _context;

        public RepositoryBase(DockerSampleContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity obj) => _context.Add(obj).Entity;

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity GetById(Guid id) => _context.Set<TEntity>().Find(id);

        public void Remove(Guid id) => _context.Remove(GetById(id));

        public void Update(TEntity obj) => _context.Entry(obj).State = EntityState.Modified;
    }
}
