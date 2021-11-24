using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);

        void DeleteById(object id);

        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TEntity>> selector = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool noTracking = true, int? pageNumber = null, int? pageSize = null);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(object id);
        TEntity Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
        void Update(TEntity entityToUpdate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity,TEntity>> selector = null,
                                                               string includeProperties = "");

        Task<bool> Any(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

    }
}
