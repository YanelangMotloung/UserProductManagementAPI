using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserProductManagementAPI.Infrastructure
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        int Create(T t);
        int Update(T t);
        void Delete(T t);
    }
}
