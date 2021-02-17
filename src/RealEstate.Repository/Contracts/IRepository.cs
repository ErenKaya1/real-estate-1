using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace src.RealEstate.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> FindOne(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}