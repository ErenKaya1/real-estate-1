using System.Linq;
using System.Threading.Tasks;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Service.Contracts
{
    public interface ITitleDeedStatusService
    {
        Task<bool> AddOneAsync(TitleDeedStatus entity);
        IQueryable<TitleDeedStatus> GetAll();
        Task<TitleDeedStatus> GetByIdAsync(int id);
        Task<bool> EditAsync(TitleDeedStatus entity);
    }
}