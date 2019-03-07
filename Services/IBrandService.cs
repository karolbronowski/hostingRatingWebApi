using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Services
{
    public interface IBrandService
    {
        Task<BrandDTO> GetAsync(Guid id);
        Task<List<BrandDTO>> BrowseAsync();
        Task<BrandDTO> CreateAsync(Brand brand);
        Task DeleteAsync(Guid id);
    }
}