using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface ITitleDeedStatusService
    {
        Task<bool> AddOneAsync(TitleDeedStatus entity);
    }
}