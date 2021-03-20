using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IExternalPropertyService
    {
        Task<SaveResult> AddOneAsync(ExternalProperty entity);
        IQueryable<ExternalProperty> GetAll();
        IQueryable<ExternalProperty> GetAll(CultureInfo culture);
        Task<ExternalProperty> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(ExternalProperty entity);
        Task<SaveResult> DeleteByIdAsync(int id);
        Task<SaveResult> AddEstateExternalPropertyAsync(List<EstateExternalProperty> entities);
    }
}