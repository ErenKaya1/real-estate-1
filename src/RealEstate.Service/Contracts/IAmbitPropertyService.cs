using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IAmbitPropertyService
    {
        Task<SaveResult> AddOneAsync(AmbitProperty entity);
        IQueryable<AmbitProperty> GetAll();
        IQueryable<AmbitProperty> GetAll(CultureInfo culture);
        Task<AmbitProperty> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(AmbitProperty entity);
        Task<SaveResult> DeleteByIdAsync(int id);
        Task<SaveResult> AddEstateAmbitPropertyAsync(List<EstateAmbitProperty> entities);
    }
}