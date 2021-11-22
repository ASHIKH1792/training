using DManage.SystemManagement.Domain.Interface;
using DManage.SystemManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        public virtual async Task<IEnumerable<TEntity>> Get(
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
                return await orderBy(query)?.ToListAsync();
            }
            else
            {
                return await query?.ToListAsync();
            }

        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }


        public virtual async Task<TEntity> GetById(object id)
        {
            return await dbSet.FindAsync(id);
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

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
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
                return await query?.FirstOrDefaultAsync(filter);
            }
            return await query.FirstOrDefaultAsync();

        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
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
            return  query.FirstOrDefault();

        }

        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
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
                return await query?.AnyAsync(filter);
            }
            return await query.AnyAsync();

        }
    }
}
