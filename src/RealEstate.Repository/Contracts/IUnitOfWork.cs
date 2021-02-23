using System;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
        Task<DeleteResponse> SaveChangesForDelete();
        IRepository<InteriorProperty> InteriorPropertyRepository { get; }
        IRepository<ExternalProperty> ExternalPropertyRepository { get; }
        IRepository<AmbitProperty> AmbitPropertyRepository { get; }
        IRepository<TransportationProperty> TransportationPropertyRepository { get; }
        IRepository<EstateType> EstateTypeRepository { get; }
        IRepository<Province> ProvinceRepository { get; }
        IRepository<District> DistrictRepository { get; }
        IRepository<WarmingWay> WarmingWayRepository { get; }
        IRepository<BuildingType> BuildingTypeRepository { get; }
        IRepository<TitleDeedStatus> TitleDeedStatusRepository { get; }
        IRepository<Estate> EstateRepository { get; }
    }
}