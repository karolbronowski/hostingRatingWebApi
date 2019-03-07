using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.Repositories
{
    public interface IBrandRepository
    {
        Task<Brand> GetAsync(Guid id);
        Task<List<Brand>> BrowseAsync();
        Task<Brand> CreateAsync(Brand brand);
        Task DeleteAsync(Brand brand);
    }
}