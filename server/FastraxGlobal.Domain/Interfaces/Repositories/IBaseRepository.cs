using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastraxGlobal.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetSingle(long id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<TResult> GetSingle<TResult>(string sql) where TResult : class, new();
        Task<T> GetSingleAsync(long id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        void Upsert(T entity, Expression<Func<T, object>> match);
        void Upsert(T entity, Expression<Func<T, object>> match, Expression<Func<T, T>> updater);
        void BatchUpsert(List<T> entities, Expression<Func<T, object>> match);
        void BatchUpdate(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory);
        void BatchDelete(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Edit(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Commit();
        IQueryable<T> ExecuteQuery(string _sql);
        IEnumerable<TResult> ExecuteQuery<TResult>(string sql, params object[] sqlParam) where TResult : class;
        IQueryable<T> ToPagedQuery(long pageSize, long pageNumber);
        long Count();
        Dictionary<string, List<string>> ErrorMessage { get; }
        bool IsValid();
    }
}
