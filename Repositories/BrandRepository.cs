using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hostingRatingWebApi.Database;
using hostingRatingWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace hostingRatingWebApi.Repositories {
    public class BrandRepository : IBrandRepository {

        private readonly DatabaseContext _databaseContext;

        public BrandRepository (DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<List<Brand>> BrowseAsync () {
            return await Task.FromResult(_databaseContext.Brands.Include(x=>x.BrandPackages).ThenInclude(x=>x.Rates).ToList());
        }

        public async Task<Brand> CreateAsync (Brand brand) {

            _databaseContext.Add(brand);
            await _databaseContext.SaveChangesAsync();
            await Task.CompletedTask;
            return brand;
        }

        public async Task DeleteAsync (Brand brand) {

            _databaseContext.Remove(brand);
            await _databaseContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Brand> GetAsync (Guid id) {
            return await Task.FromResult(_databaseContext.Brands.Include(x=>x.BrandPackages).SingleOrDefault(x=>x.Id == id));
        }
    }
}