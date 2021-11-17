using DManage.SystemManagement.Domain.Interface;
using DManage.SystemManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DManage.SystemManagement.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal SystemManagementDbContext _context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(SystemManagementDbContext context)
        {

            _context = context;
            dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {

            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query?.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query)?.ToList();
            }
            else
            {
                return query?.ToList();
            }

        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }


        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }


        public virtual TEntity Insert(TEntity entity)
        {
            var entityAdded = dbSet.Add(entity);
            return entityAdded.Entity;
        }


        public virtual void DeleteById(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToSoftDelete)
        {
            dbSet.Attach(entityToSoftDelete);
            _context.Entry(entityToSoftDelete).State = EntityState.Deleted;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {

            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (filter != null)
            {
                return query?.FirstOrDefault(filter);
            }
            return query.FirstOrDefault();

        }
    }
}
