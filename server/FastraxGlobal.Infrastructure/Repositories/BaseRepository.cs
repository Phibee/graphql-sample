using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FastraxGlobal.Domain.Interfaces.Repositories;
using FastraxGlobal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FastraxGlobal.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private DbContext _context;

        public BaseRepository(DbContext context) { this._context = context; }

        public Dictionary<string, List<string>> ErrorMessage { get; }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void BatchDelete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void BatchUpdate(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory)
        {
            throw new NotImplementedException();
        }

        public void BatchUpsert(List<T> entities, Expression<Func<T, object>> match)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);

            dbEntityEntry.State = EntityState.Deleted;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ExecuteQuery(string _sql)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> ExecuteQuery<TResult>(string sql, params object[] sqlParam) where TResult : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetSingle(long id)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GetSingle<TResult>(string sql) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ToPagedQuery(long pageSize, long pageNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Upsert(T entity, Expression<Func<T, object>> match)
        {
            throw new NotImplementedException();
        }

        public void Upsert(T entity, Expression<Func<T, object>> match, Expression<Func<T, T>> updater)
        {
            throw new NotImplementedException();
        }
    }
}
