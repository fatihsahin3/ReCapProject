using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // generic constraint
    // class : reference type
    // IEntity : It can be IEntity or classes those implements IEntity
    // new() : It can be only classes from which a new instance can be initiated.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
