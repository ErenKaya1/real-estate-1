using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IWarmingWayService
    {
        Task<bool> AddOneAsync(WarmingWay entity);
        IQueryable<WarmingWay> GetAll();
    }
}