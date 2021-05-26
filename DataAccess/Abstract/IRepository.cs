using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
     public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        void Delete(T p);
        void Update(T p);
        List<T> List(Expression<Func<T, bool>> filter);

    }
}
