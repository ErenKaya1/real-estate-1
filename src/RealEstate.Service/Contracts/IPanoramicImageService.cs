using Microsoft.AspNetCore.Http;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace src.RealEstate.Service.Contracts
{
    public interface IPanoramicImageService
    {
        Task<SaveResult> AddRangeAsync(List<IFormFile> images, string estateId, string imageOrders);
    }
}