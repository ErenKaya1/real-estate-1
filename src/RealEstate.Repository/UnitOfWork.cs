using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using src.RealEstate.Common.Enum;
using src.RealEstate.Dal.Context;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository.Contracts;

namespace src.RealEstate.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly EstateContext _dbContext;
        private IRepository<InteriorProperty> _interiorPropertyRepository;
        private IRepository<ExternalProperty> _externalPropertyRepository;
        private IRepository<AmbitProperty> _ambitPropertyRepository;
        private IRepository<TransportationProperty> _transportationRepository;
        private IRepository<EstateType> _estateTypeRepository;
        private IRepository<Province> _provinceRepository;
        private IRepository<District> _districtRepository;
        private IRepository<WarmingWay> _warmingWayRepository;
        private IRepository<BuildingType> _buildingTypeRepository;
        private IRepository<TitleDeedStatus> _titleDeedStatusRepository;
        private IRepository<Estate> _estateRepository;
        private IRepository<StaticImage> _staticImageRepository;
        private IRepository<PanoramicImage> _panoramicImageRepository;

        public IRepository<InteriorProperty> InteriorPropertyRepository => _interiorPropertyRepository ??= new Repository<InteriorProperty>(_dbContext);
        public IRepository<ExternalProperty> ExternalPropertyRepository => _externalPropertyRepository ??= new Repository<ExternalProperty>(_dbContext);
        public IRepository<AmbitProperty> AmbitPropertyRepository => _ambitPropertyRepository ??= new Repository<AmbitProperty>(_dbContext);
        public IRepository<TransportationProperty> TransportationPropertyRepository => _transportationRepository ??= new Repository<TransportationProperty>(_dbContext);
        public IRepository<EstateType> EstateTypeRepository => _estateTypeRepository ??= new Repository<EstateType>(_dbContext);
        public IRepository<Province> ProvinceRepository => _provinceRepository ??= new Repository<Province>(_dbContext);
        public IRepository<District> DistrictRepository => _districtRepository ??= new Repository<District>(_dbContext);
        public IRepository<WarmingWay> WarmingWayRepository => _warmingWayRepository ??= new Repository<WarmingWay>(_dbContext);
        public IRepository<BuildingType> BuildingTypeRepository => _buildingTypeRepository ??= new Repository<BuildingType>(_dbContext);
        public IRepository<TitleDeedStatus> TitleDeedStatusRepository => _titleDeedStatusRepository ??= new Repository<TitleDeedStatus>(_dbContext);
        public IRepository<Estate> EstateRepository => _estateRepository ??= new Repository<Estate>(_dbContext);
        public IRepository<StaticImage> StaticImageRepository => _staticImageRepository ??= new Repository<StaticImage>(_dbContext);
        public IRepository<PanoramicImage> PanoramicImageRepository => _panoramicImageRepository ??= new Repository<PanoramicImage>(_dbContext);

        public UnitOfWork(EstateContext dbContext)
        {
            if (dbContext == null) return;
            _dbContext = dbContext;
        }

        public async Task<SaveResult> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return SaveResult.Success;
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (MySqlException)ex?.InnerException;

                switch (sqlEx.Number)
                {
                    case 1451:
                        return SaveResult.InUse;
                    case 1062:
                        return SaveResult.Duplicated;
                    default:
                        return SaveResult.Fail;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                return SaveResult.Fail;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}