using System;
using System.Threading.Tasks;

namespace src.RealEstate.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
    }
}