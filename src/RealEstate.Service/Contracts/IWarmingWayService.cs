using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IWarmingWayService
    {
        Task<bool> AddOneAsync(WarmingWay entity);
        IQueryable<WarmingWay> GetAll();
        IQueryable<WarmingWay> GetAll(CultureInfo culture);
        Task<WarmingWay> GetByIdAsync(int id);
        Task<bool> EditAsync(WarmingWay entity);
        Task<DeleteResponse> DeleteByIdAsync(int id);
    }
}