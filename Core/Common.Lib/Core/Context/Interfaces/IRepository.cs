using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Common.Lib.Core.Context
{
    /// <summary>
    /// Basic CRUD methods 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IQueryable<T> QueryAll();

        T Find(int id);

        OperationResult<T> Add(T entity);

        OperationResult<T> Update(T entity);

        OperationResult<T> Delete(T entity);
    }
}
