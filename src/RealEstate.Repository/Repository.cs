using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Dal.Context;
using src.RealEstate.Repository.Contracts;

namespace src.RealEstate.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EstateContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(EstateContext dbContext)
        {
            if (dbContext == null) return;

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}