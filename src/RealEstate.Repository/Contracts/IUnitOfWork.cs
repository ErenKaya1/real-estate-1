using System;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
        IRepository<InteriorProperty> InteriorPropertyRepository { get; }
        IRepository<ExternalProperty> ExternalPropertyRepository { get; }
        IRepository<AmbitProperty> AmbitPropertyRepository { get; }
        IRepository<TransportationProperty> TransportationPropertyRepository { get; }
    }
}