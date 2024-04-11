using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EF
{
    public class EFEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _db;
        public EFEntityRepositoryBase(DbContext db)
        {
            _db = db;  
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? _db.Set<TEntity>() : _db.Set<TEntity>().Where(filter);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _db.Set<TEntity>().SingleOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public void Add(IList<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities), "Entity list cannot be null or empty.");

            _db.Set<TEntity>().AddRange(entities);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            _db.Set<TEntity>().Update(entity);
            _db.SaveChanges();
        }

        public void Update(IList<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities), "Entity list cannot be null or empty.");

            _db.Set<TEntity>().UpdateRange(entities);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            _db.Set<TEntity>().Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(IList<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities), "Entity list cannot be null or empty.");

            _db.Set<TEntity>().RemoveRange(entities);
            _db.SaveChanges();
        }




    }
}
