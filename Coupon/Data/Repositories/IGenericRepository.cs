using System;
using System.Collections.Generic;

namespace Coupon.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        T Get(Guid id);
        void Delete(int id);
        void Update(T entity);
        List<T> List();
    }
}
