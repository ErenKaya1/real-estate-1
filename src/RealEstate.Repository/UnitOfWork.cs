using System;
using System.Threading.Tasks;
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

        public IRepository<InteriorProperty> InteriorPropertyRepository => _interiorPropertyRepository ??= new Repository<InteriorProperty>(_dbContext);
        public IRepository<ExternalProperty> ExternalPropertyRepository => _externalPropertyRepository ??= new Repository<ExternalProperty>(_dbContext);
        public IRepository<AmbitProperty> AmbitPropertyRepository => _ambitPropertyRepository ??= new Repository<AmbitProperty>(_dbContext);

        public UnitOfWork(EstateContext dbContext)
        {
            if (dbContext == null) return;
            _dbContext = dbContext;
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return false;
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