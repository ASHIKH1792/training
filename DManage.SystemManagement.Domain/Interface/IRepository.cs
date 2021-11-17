using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DManage.SystemManagement.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);

        void DeleteById(object id);

        IEnumerable<TEntity> Get(

            Expression<Func<TEntity, bool>> filter = null,

            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,

            string includeProperties = "");
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        TEntity Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

    }
}
