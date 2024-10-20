using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> Table;
        public EfRepositoryBase(DbContext context)
        {
            _context = context;
            Table = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Deleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (includes != null) query = includes(query);

            return query.FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    bool isGetPaging = true, int page = 0, int length = 5)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (filter != null) query = query.Where(filter);
            if (includes != null) query = includes(query);
            if (orderBy != null) query = orderBy(query);

            if (isGetPaging) query = query.Skip(page * length).Take(length);
            return query.ToList();
        }

        public void Update(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public int GetDataCount(Expression<Func<TEntity, bool>> filter = null)
        {
            int result = filter == null ? _context.Set<TEntity>().Count()
                                        : _context.Set<TEntity>().Count(filter);
            return result;
        }

        public void BulkAdd(IList<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
        }
    }
}
