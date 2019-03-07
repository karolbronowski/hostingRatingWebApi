using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hostingRatingWebApi.Database;
using hostingRatingWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace hostingRatingWebApi.Repositories
{
    public class BrandPackageRepository : IBrandPackageRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BrandPackageRepository (DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        public async Task<List<BrandPackage>> BrowseAsync()
        {
            return await Task.FromResult(_databaseContext.BrandPackages.Include(x=>x.Brand).Include(x=>x.Rates).ToList());
        }

        public async Task<BrandPackage> CreateAsync(BrandPackage brand)
        {
             _databaseContext.Add(brand);
            await _databaseContext.SaveChangesAsync();
            await Task.CompletedTask;
            return brand;
        }

        public async Task DeleteAsync(BrandPackage brand)
        {
            _databaseContext.Remove(brand);
            await _databaseContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<BrandPackage> GetAsync(Guid id)
        {
            return await Task.FromResult(_databaseContext.BrandPackages.Include(x=>x.Brand).SingleOrDefault(x=>x.Id == id));
        }
    }
}