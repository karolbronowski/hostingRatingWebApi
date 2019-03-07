using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Repositories
{
    public interface IBrandPackageRepository
    {
        Task<BrandPackage> GetAsync(Guid id);
        Task<List<BrandPackage>> BrowseAsync();
        Task<BrandPackage> CreateAsync(BrandPackage brand);
        Task DeleteAsync(BrandPackage brand);
    }
}