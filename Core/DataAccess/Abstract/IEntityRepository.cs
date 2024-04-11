using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class ,IEntity, new() 
    {
       IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null);
       T Get(Expression<Func<T, bool>> filter);
       void Add(T entity);
       void Add(IList<T> entities);
       void Update(T entity);
       void Update(IList<T> entities);
       void Delete(T entity);
       void Delete(IList<T> entities);
    }
}
