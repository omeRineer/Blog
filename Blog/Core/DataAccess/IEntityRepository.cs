using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                             bool isGetPaging = true, int page = 0, int length = 5);
        TEntity Get(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

        int GetDataCount(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void BulkAdd(IList<TEntity> entities);
        void Delete(TEntity entity);
        void Update(TEntity entity);


        void Save();
    }
}
