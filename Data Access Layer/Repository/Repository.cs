using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
namespace Data_Access_Layer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SWDContext Context;

        public Repository(SWDContext context)
        {
            Context = context;
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id) ?? throw new Exception("Entity not found.");
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}