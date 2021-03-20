using src.RealEstate.Service.Contracts;
using src.RealEstate.Repository.Contracts;
using System.Threading.Tasks;
using src.RealEstate.Common.Enum;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RealEstate.Common.Functions.Extensions;
using System.Linq;
using src.RealEstate.Entity.Entities;
using System.IO;

namespace src.RealEstate.Service
{
    public class StaticImageService : IStaticImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public StaticImageService(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<SaveResult> AddRangeAsync(List<IFormFile> images, string estateId, string imageOrders)
        {
            var orders = string.IsNullOrEmpty(imageOrders) ? new List<string>() : imageOrders.Split(';').ToList();
            var wwwrootPath = _hostEnvironment.WebRootPath;
            var estateImagesPath = Path.Combine(wwwrootPath, "images", estateId);
            if (!Directory.Exists(estateImagesPath)) Directory.CreateDirectory(estateImagesPath);
            var staticImagesPath = Path.Combine(estateImagesPath, "static");
            if (!Directory.Exists(staticImagesPath)) Directory.CreateDirectory(staticImagesPath);

            foreach (var image in images)
            {
                if (!image.IsImage()) continue;
                _unitOfWork.StaticImageRepository.Add(new StaticImage
                {
                    EstateId = int.Parse(estateId),
                    ImageName = image.FileName,
                    Order = orders.Count == 0 ? 0 : orders.IndexOf(orders.First(x => x == image.FileName))
                });

                using var stream = new FileStream(Path.Combine(staticImagesPath, image.FileName), FileMode.Create);
                await image.CopyToAsync(stream);
            }

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}