using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface ITransportationPropertyService
    {
        Task<SaveResult> AddOneAsync(TransportationProperty entity);
        IQueryable<TransportationProperty> GetAll();
        IQueryable<TransportationProperty> GetAll(CultureInfo culture);
        Task<TransportationProperty> GetByIdAsync(int id);
        Task<SaveResult> EditAsync(TransportationProperty entity);
        Task<SaveResult> DeleteByIdAsync(int id);
        Task<SaveResult> AddEstateTransportationPropertyAsync(List<EstateTransportationProperty> entities);
    }
}