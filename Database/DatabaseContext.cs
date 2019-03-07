using hostingRatingWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace hostingRatingWebApi.Database
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }
        public DbSet<User> Users {get;set;}
        public DbSet<Brand> Brands {get;set;}
        public DbSet<BrandPackage> BrandPackages {get;set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>( x=> {
                x.HasMany(z=>z.AddedBrands).WithOne(c=>c.Creator).OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<Brand>( x=> {
                x.HasOne(z=>z.Creator).WithMany(c=>c.AddedBrands).OnDelete(DeleteBehavior.Restrict);
                x.HasMany(z=>z.BrandPackages).WithOne(c=>c.Brand).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Rate>( x=> {
                x.HasOne(z=>z.BrandPackage).WithMany(c=>c.Rates).OnDelete(DeleteBehavior.Restrict);

            });
             modelBuilder.Entity<BrandPackage>( x=> {
               x.HasOne(z=>z.Brand).WithMany(c=>c.BrandPackages).OnDelete(DeleteBehavior.Restrict);
                x.HasMany(z=>z.Rates).WithOne(c=>c.BrandPackage).OnDelete(DeleteBehavior.Restrict);
            });


            
        }
    }
}