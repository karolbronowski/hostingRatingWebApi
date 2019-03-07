using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Services
{
    public interface IBrandPackageService
    {
        Task<BrandPackageDTO> GetAsync(Guid id);
        Task<List<BrandPackageDTO>> BrowseAsync();
        Task<BrandPackageDTO> CreateAsync(BrandPackage brand);
        Task DeleteAsync(Guid id);
    }
}