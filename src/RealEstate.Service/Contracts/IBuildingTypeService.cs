using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface IBuildingTypeService
    {
        Task<bool> AddOneAsync(BuildingType entity);
        IQueryable<BuildingType> GetAll();
    }
}