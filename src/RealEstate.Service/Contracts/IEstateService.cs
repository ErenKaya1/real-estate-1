using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using System.Threading.Tasks;

namespace src.RealEstate.Service.Contracts
{
    public interface IEstateService
    {
        Task<(SaveResult, int)> AddOneAsync(Estate entity);
    }
}